using System;
using System.IO;

namespace Task_4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string PathOfDirectory_1 = @"/Users/macbook/Desktop/path";
            string PathOfDirectory_2 = @"/Users/macbook/Desktop/path2";
            if (!Directory.Exists(PathOfDirectory_1))
            {
                Directory.CreateDirectory(PathOfDirectory_1);
            }
            if (!Directory.Exists(PathOfDirectory_2))
            {
                Directory.CreateDirectory(PathOfDirectory_2);
            }
            string file_name = "input.txt";

            string file_1 = Path.Combine(PathOfDirectory_1, file_name);
            string file_2 = Path.Combine(PathOfDirectory_2, file_name);

            FileStream fs = new FileStream(file_1, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            StreamWriter s = new StreamWriter(fs);

            s.WriteLine(Console.ReadLine());
            s.Close();

            if (File.Exists(file_2))
            {
                File.Delete(file_2);
            }
            //File.Move(file_1, file_2);
            File.Copy(file_1, file_2);
            File.Delete(file_1);

        }
    }
}
