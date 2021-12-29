using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace Medilab.UserInterface.Utils
{
    public static class FileDirectoryHandler
    {
        public static bool CheckIfDirectoryExist(string path)
        {
            if (Directory.Exists(path))
            {
                return true;
            }
            return false;
        }

        public static void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
        /// <summary>
        /// Copy the file to one location to another
        /// </summary>
        /// <param name="from">origin</param>
        /// <param name="to">destination</param>
        public static void CopyFile(string from, string to, string fileName)
        {
            string fileNamePath = Path.Combine(to, fileName);
            if (File.Exists(fileNamePath))
            {
                File.Delete(fileNamePath);
            }
            File.Copy(from, fileNamePath);
        }
        public static void DeleteFile(string filePath, string fileName)
        {
            File.Delete(Path.Combine(filePath,fileName));
        }
            

    }
}
