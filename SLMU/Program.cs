using System;
using System.IO;
using System.IO.Compression;

namespace SLMU
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Insert the Path of the Directory you want to zip the files in:");
            var path = Console.ReadLine();
            
            Console.WriteLine("\n\n");
            
            // get all files
            DirectoryInfo d = new DirectoryInfo(@path);
            FileInfo[] files = d.GetFiles("*.jar");

            for (int i = 0; i < files.Length; i++)
            {
                // get file name
                var file = files[i];
                var fileName = file.Name.ToLower().Replace("_", "-");
                var newFileName = fileName.Replace(".jar", string.Empty);
                
                // set new locations
                var newFolder = path + newFileName;
                var newModsFolder = path + newFileName + "/mods";
                var newConfigFolder = path + newFileName + "/config";
                
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