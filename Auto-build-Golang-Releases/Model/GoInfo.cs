using System;
using System.IO;

namespace Auto_build_Golang_Releases.Model
{
    public class GoInfo : Attribute
    {
        public GoInfo(
            string goos,
            string goArch,
            string appFileName = default,
            string zipFileName = default,
            bool isWindows = false
        )
        {
            Goos = goos;
            GoArch = goArch;
            AppFileName = appFileName;
            ZipFileName = zipFileName;

            if (appFileName == default)
            {
                AppFileName = $"{Goos}_{GoArch}";
            }

            if (zipFileName == default)
            {
                ZipFileName = $"{AppFileName}.zip";
            }

            if (isWindows)
            {
                AppFileName += ".exe";
            }

            AppFileParentPath = Path.Combine(FolderName, $"{Goos}_{GoArch}");
            AppFilePath = Path.Combine(AppFileParentPath, AppFileName);
            ZipFilePath = Path.Combine(FolderName, ZipFileName);
        }

        public string AppFileParentPath { get; set; }
        public string Goos { get; set; }

        public string GoArch { get; set; }

        public string AppFileName { get; set; }
        public string AppFilePath { get; set; }
        public string ZipFileName { get; set; }
        public string ZipFilePath { get; set; }
        public string FolderName { get; set; } = "releases";
    }
}