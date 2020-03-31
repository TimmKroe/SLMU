using System;
using System.IO;
using System.IO.Compression;
using Microsoft.VisualBasic;

namespace SLMU
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Insert the Path of the Directory you want to zip the files in:");
            string path = Console.ReadLine();

            Console.WriteLine("\n\n");

            Console.WriteLine("[INFO] Loading all Files......");
            // get all files
            DirectoryInfo d = new DirectoryInfo(@path);
            FileInfo[] files = d.GetFiles("*.jar");


            for (int i = 0; i < files.Length; i++)
            {
                // get file name
                FileInfo file = files[i];
                string fileName = file.Name.ToLower()
                    .Replace("_", "-")
                    .Replace(" ", "")
                    .Replace("'", "")
                    .Replace("+", "");
                string newFileName = fileName.Replace(".jar", string.Empty);
                Console.WriteLine("[INFO] normalizing filename - (" + file.Name + ")");

                // set new locations
                string newFolder = path + newFileName;
                string newModsFolder = path + newFileName + "/mods";
                string newConfigFolder = path + newFileName + "/config";

                Console.WriteLine("[INFO] creating Directories for (" + newFileName + ")");
                // create folder with name
                Directory.CreateDirectory(newFolder);
                Directory.CreateDirectory(newModsFolder);
                Directory.CreateDirectory(newConfigFolder);

                Console.WriteLine("[INFO] Moving file into directory");
                // put file into mods folder inside the new folder
                File.Move(path + file.Name, newModsFolder + "\\" + fileName);

                Console.WriteLine("[INFO] creating zip archive...");
                // zip that folder
                ZipFile.CreateFromDirectory(newFolder, newFolder + ".zip");
                Console.WriteLine("[INFO] (" + file.Name + ") done. \n");
            }

            Console.WriteLine("[INFO] Process has finished. DONE.");
            Console.ReadLine();
        }
    }
}