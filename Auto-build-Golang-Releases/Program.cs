using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using Auto_build_Golang_Releases.Model;
using CommandLine;
using Furion.Tools.CommandLine;

namespace Auto_build_Golang_Releases
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Entry(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("程序发生异常");
                Console.ReadLine();
            }
        }

        // 线程数
        public static int _count = 0;

        public static void Entry(string[] args)
        {
            CliExtend.WriteSplitLine("启动成功");

            Parser.Default.ParseArguments<MyOptions>(args)
                .WithParsed(options =>
                {
                    // var workDir = @"E:\Work\GoProject\go-auto-releases";
                    // Environment.CurrentDirectory = workDir;

                    if (options.Win32 || options.All)
                    {
                        RunBuild(nameof(MyOptions.Win32));
                    }

                    if (options.Win64 || options.All)
                    {
                        RunBuild(nameof(MyOptions.Win64));
                    }

                    if (options.Linux32 || options.All)
                    {
                        RunBuild(nameof(MyOptions.Linux32));
                    }

                    if (options.Linux64 || options.All)
                    {
                        RunBuild(nameof(MyOptions.Linux64));
                    }

                    if (options.Macos64 || options.All)
                    {
                        RunBuild(nameof(MyOptions.Macos64));
                    }
                });

            var i = 0;
            while (true)
            {
                Cli.Write($"当前 {_count} 个线程正在运行...");
                Thread.Sleep(500);
                CliExtend.ResetLine();
                if (_count == 0)
                    i++;
                else
                    i = 0;

                if (i == 3)
                {
                    break;
                }
            }

            CliExtend.WriteSplitLine($"全部结束,按回车键退出程序");

            Console.ReadLine();
        }

        public static void RunBuild(string propName)
        {
            Task.Run(async () =>
            {
                Interlocked.Increment(ref _count);

                try
                {
                    var info = MyUtils.GetGoInfo(propName);
                    await CliWrap.Cli
                        .Wrap("go")
                        .WithArguments($"build -o {info.AppFilePath}")
                        .WithEnvironmentVariables(builder =>
                            {
                                builder.Set("GOOS", info.Goos);
                                builder.Set("GOARCH", info.GoArch);
                            }
                        )
                        .ExecuteAsync();

                    if (new FileInfo(info.AppFilePath).Exists)
                    {
                        // 删除现有的同名 zip
                        new FileInfo(info.ZipFilePath).Delete();
                        // 压缩
                        ZipFile.CreateFromDirectory(info.AppFileParentPath, info.ZipFilePath);
                        // 删除未被压缩的文件夹
                        new DirectoryInfo(info.AppFileParentPath).Delete(true);
                    }
                    else
                    {
                        CliExtend.WriteSplitLine($"{info.AppFilePath}编译失败");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Interlocked.Decrement(ref _count);
            });
        }
    }
}