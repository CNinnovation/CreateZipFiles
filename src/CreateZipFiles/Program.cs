using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace CreateZipFiles
{
    public class Program
    {
        private const string SourceArchive = @"C:\Users\chris\Downloads\ProfessionalCSharp6-master.zip";
        private const string TempFolder = @"c:\temp\procsharp";
        private const string TempFolder2 = @"c:\temp\procsharp\ProfessionalCSharp6-master";
        private const string ResultFolder = @"c:\temp\results";

        private static Dictionary<string, string> ZipFileMapping;


        public static void Main(string[] args)
        {
            InitZipFileMapping();
            Run();
        }

        private static void Run()
        {
            if (!UncompressFiles()) return;
           
            foreach (var zipFile in ZipFileMapping.Keys)
            {
                if (!Directory.Exists(ResultFolder))
                {
                    Directory.CreateDirectory(ResultFolder);
                }
                string zipPath = Path.Combine(ResultFolder, zipFile);
                string sourcePath = Path.Combine(TempFolder2, ZipFileMapping[zipFile]);
                ZipFile.CreateFromDirectory(sourcePath, zipPath);
                Console.WriteLine($"created {zipPath}");
            }
        }

        private static bool UncompressFiles()
        {
            Console.WriteLine("Uncompressing files...");
            if (Directory.Exists(TempFolder))
            {
                Console.WriteLine($"delete {TempFolder} before running this app");
                return false;
            }
            Directory.CreateDirectory(TempFolder);

            ZipFile.ExtractToDirectory(SourceArchive, TempFolder);
            Console.WriteLine($"Uncompressed files to {TempFolder}");
            return true;
        }

        private static void InitZipFileMapping()
        {
            ZipFileMapping = new Dictionary<string, string>()
            {
                ["01_code.zip"] = "HelloWorld",
                ["02_code.zip"] = "CoreCSharp",
                ["03_code.zip"] = "ObjectsAndTypes",
                ["04_code.zip"] = "Inheritance",
                ["05_code.zip"] = "Resources",
                ["06_code.zip"] = "Generics",
                ["07_code.zip"] = "Arrays",
                ["08_code.zip"] = "OperatorsAndCasts",
                ["09_code.zip"] = "Delegates",
                ["10_code.zip"] = "StringsAndRegularExpressions",
                ["11_code.zip"] = "Collections",
                ["12_code.zip"] = "SpecialCollections",
                ["13_code.zip"] = "LINQ",
                ["14_code.zip"] = "ErrorsAndExceptions",
                ["15_code.zip"] = "Async",
                ["16_code.zip"] = "ReflectionAndDynamic",
                ["17_code.zip"] = "VisualStudio2015",
                ["18_code.zip"] = "CompilerPlatform",
                ["19_code.zip"] = "Testing",
                ["20_code.zip"] = "Diagnostics",
                ["21_code.zip"] = "Parallel",
                ["22_code.zip"] = "Synchronization",
                ["23_code.zip"] = "FilesAndStreams",
                ["24_code.zip"] = "Security",
                ["25_code.zip"] = "Networking",
                ["26_code.zip"] = "Composition",
                ["27_code.zip"] = "XMLandJSON",
                ["28_code.zip"] = "Localization",
                ["29_code.zip"] = "XAML",
                ["30_code.zip"] = "StylesAndResources",
                ["31_code.zip"] = "Patterns",
                ["32_code.zip"] = "WindowsApps",
                ["33_code.zip"] = "AdvancedWindowsApps",
                ["34_code.zip"] = "WPF",
                ["35_code.zip"] = "WPFDocuments",
                ["36_code.zip"] = "DeploymentWindows",
                ["37_code.zip"] = "ADONET",
                ["38_code.zip"] = "EntityFramework",
                ["39_code.zip"] = "Services",
                ["40_code.zip"] = "ASPNET",
                ["41_code.zip"] = "ASPNETMVC",
                ["42_code.zip"] = "WebAPI",
                ["43_code.zip"] = "SignalRAndWebHooks",
                ["44_code.zip"] = "WCF",
                ["45_code.zip"] = "DeploymentWeb"
            };
        }
    }
}
