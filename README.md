# Auto-build-Golang-Releases

> 一键自动交叉编译golang的二进制文件

# 使用

> 在你的`go项目的根目录`执行命令(需要安装`dotnet-tool` 或者 将编译后的exe加入到`系统环境变量Path`中)
>
> 最终文件会放在`releases`文件夹中

```shell
# 编译全部平台
gor -a
# win 64
gor -w
# linux 64
gor -l
# macos 64
gor -m

# 显示所有参数帮助
gor --help
```



```shell
PS E:\Work\CSharpProject\Auto-build-Golang-Releases\Auto-build-Golang-Releases> gor --help

=========================== 启动成功 ===========================

Auto-build-Golang-Releases 1.0.1
Copyright (C) 2021 Auto-build-Golang-Releases

  --win32          编译出 windows 32位 go程序

  -w, --win64      编译出 windows 64位 go程序

  --linux32        编译出 linux 32位 go程序

  -l, --linux64    编译出 linux 64位 go程序

  -m, --macos      编译出 macos 64位 go程序

  -a, --all        编译所有平台的go程序

  --help           Display this help screen.

  --version        Display version information.

当前 0 个线程正在运行...
=========================== 全部结束,按回车键退出程序 ===========================
```

# dotnet tool 全局安装

> 在 `Auto-build-Golang-Releases.csproj`所在的目录, 使用命令行执行以下命令即可

> 使用`dotnet tool` 需要安装 `.Net5 SDK` 
>
> 在 SDK 5.x  Installers中,选择自己的系统 ,安装即可
>
> [Download .NET 5.0 (Linux, macOS, and Windows) (microsoft.com)](https://dotnet.microsoft.com/download/dotnet/5.0)

```shell
# 安装
dotnet tool install --global --add-source ./nupkg Auto-build-Golang-Releases
# 更新
dotnet tool update --global --add-source ./nupkg Auto-build-Golang-Releases
# 卸载
dotnet tool uninstall --global Auto-build-Golang-Releases
```



# 支持作者

如果这个开源项目 可以帮助到你, 你也可以请作者吃一包辣条。

![pay](img.assets/pay.png)





