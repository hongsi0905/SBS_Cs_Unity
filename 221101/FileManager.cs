using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _221101
{
    internal class FileManager
    {
        private static string GetPath(string filename)
        {
            string root = Directory.GetCurrentDirectory();
            return Path.Combine(root, "Database", filename);
        }
        public static void Write(string filename, string data)
        {
            string path = GetPath(filename);
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.Write(data);
            }
            Console.WriteLine($"쓰기완료 : {path}");
        }
        public static string Read(string filename)
        {
            string data = string.Empty;

            string path = GetPath(filename);
            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                data = reader.ReadToEnd().Trim();
            }
            Console.WriteLine($"읽기완료 : {path}");
            return data;


        }
    }
}
