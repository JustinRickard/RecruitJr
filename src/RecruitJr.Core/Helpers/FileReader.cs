using System.Collections.Generic;
using System.IO;
using System.Text;
using RecruitJr.Core.Interfaces.Helpers;

namespace RecruitJr.Core.Helpers
{
    public class FileReader : IFileReader
    {
        public string Read(string path)
        {
            return File.ReadAllText(path, Encoding.UTF8);
        }

        public IEnumerable<string> ReadLines(string path)
        {
            return File.ReadLines(path, Encoding.UTF8);
        }
    }
}