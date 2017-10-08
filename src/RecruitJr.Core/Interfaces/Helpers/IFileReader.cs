using System.Collections.Generic;

namespace RecruitJr.Core.Interfaces.Helpers
{
    public interface IFileReader
    {
         string Read(string path);
         IEnumerable<string> ReadLines(string path);
    }
}