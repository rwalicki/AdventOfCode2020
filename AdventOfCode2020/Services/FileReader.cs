using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020.Services
{
    public class FileReader
    {
        public string ReadFileToPlainText(string dir)
        {
            using (var stream = new StreamReader(dir))
            {
                return stream.ReadToEnd();
            }
        }

        public List<string> ReadTextToList(string text)
        {
            return text.Split('\n').ToList();
        }
    }
}