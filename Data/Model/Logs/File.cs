using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logs
{
    public static class File
    {
        /// <summary>
        /// Writes and saves content to file.
        /// </summary>
        /// <param name="FileName">Writes to file which it is in Debug Folder if not creates it.</param>
        /// <param name="Text">What we need to saves.</param>
        public static void WriteToFile(string FileName, string Text)
        {
            StringBuilder _text = new StringBuilder(Text.ToString());
            StringBuilder file = new StringBuilder(FileName.ToString().Trim());
            if (!file.ToString().Contains(".txt"))
                file.Append(".txt");

            using (FileStream fs = new FileStream(file.ToString(), FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                {
                    writer.WriteLine(_text.ToString());
                    writer.Close();
                    writer.Dispose();
                }
                fs.Close();
                fs.Dispose();
            }

        }
        /// <summary>
        /// Reads from file.
        /// </summary>
        /// <param name="FileName">Filename or path file.</param>
        public static void ReadFromFile(string FileName)
        {
            StringBuilder file = new StringBuilder(FileName.ToString().Trim());
            if (!file.ToString().Contains(".txt"))
                file.Append(".txt");

            try
            {
                using (FileStream fs = new FileStream(file.ToString(), FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (StreamReader reader = new StreamReader(fs, Encoding.UTF8))
                    {
                        Console.WriteLine(reader.ReadLine());
                        reader.Close();
                        reader.DiscardBufferedData();
                        reader.Dispose();
                    }
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
