using System;
using Ionic.Zip;
using CommonUtils;


namespace ZipFolder
{
    static class ZipFolder
    {
        //const string defaultFolder =
        //    @"D:\Aleksandar\Documents\Visual Studio 2015";
        //const string defaultDestinationFolder =
        //    @"G:\_BACKUP\VS Backups";
        static readonly string defaultFolder = Misc.AssemblyFolder();
        static readonly string defaultDestinationFolder = defaultFolder;

        static void Main(string[] args)
        {
            string timestamp =
                DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss");

            string folderFullPath =
                args.Length > 0 ? args[0] : defaultFolder;
            string folderName = System.IO.Path.GetFileName(folderFullPath);
            string DestinationFolder =
                args.Length > 1 ? args[1] : defaultDestinationFolder;

            string zipName =
                $"{DestinationFolder}\\{folderName} as of {timestamp}.zip";

            Console.WriteLine($"\nZipping:\n{folderFullPath}\n");

            using (ZipFile zip = new ZipFile())
            {
                //zip.UseUnicodeAsNecessary = true;  // UTF-8    obsolete!
                zip.AddDirectory(folderFullPath);
                zip.Comment = "Created: " + timestamp;
                zip.Save(zipName);
            }

            Console.WriteLine($"Created:\n{zipName}\n");
            Console.Write($"Press enter to open \n{DestinationFolder} ");
            Console.ReadLine();
            DestinationFolder.LaunchFile();
            Console.WriteLine();
        }
    }
}
