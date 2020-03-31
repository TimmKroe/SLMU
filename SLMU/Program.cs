using System;
using System.IO;
using System.IO.Compression;

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

            // get all files
            DirectoryInfo d = new DirectoryInfo(@path);
            FileInfo[] files = d.GetFiles("*.jar");

            for (int i = 0; i < files.Length; i++)
            {
                // get file name
                FileInfo file = files[i];
                string fileName = file.Name.ToLower().Replace("_", "-");
                string newFileName = fileName.Replace(".jar", string.Empty);

                // set new locations
                string newFolder = path + newFileName;
                string newModsFolder = path + newFileName + "/mods";
                string newConfigFolder = path + newFileName + "/config";

                // create folder with name
                Directory.CreateDirectory(newFolder);
                Directory.CreateDirectory(newModsFolder);
                Directory.CreateDirectory(newConfigFolder);

                // put file into mods folder inside the new folder
                File.Move(path + file.Name, newModsFolder + "\\" + fileName);


                // zip that folder
                ZipFile.CreateFromDirectory(newFolder, newFolder + ".zip");

            }
        }
    }
}