using CommandLine;

namespace Auto_build_Golang_Releases.Model
{
    public class MyOptions
    {
        [Option("win32", HelpText = "编译出 windows 32位 go程序")]
        [GoInfo("windows", "386", isWindows: true)]
        public bool Win32 { get; set; }

        [Option('w', "win64", HelpText = "编译出 windows 64位 go程序")]
        [GoInfo("windows", "amd64", isWindows: true)]
        public bool Win64 { get; set; }

        [Option("linux32", HelpText = "编译出 linux 32位 go程序")]
        [GoInfo("linux", "386")]
        public bool Linux32 { get; set; }

        [Option('l', "linux64", HelpText = "编译出 linux 64位 go程序")]
        [GoInfo("linux", "amd64")]
        public bool Linux64 { get; set; }

        [Option('m', "macos", HelpText = "编译出 macos 64位 go程序")]
        [GoInfo("darwin", "amd64")]
        public bool Macos64 { get; set; }

        [Option('a', "all", HelpText = "编译所有平台的go程序")]
        public bool All { get; set; }
    }
}