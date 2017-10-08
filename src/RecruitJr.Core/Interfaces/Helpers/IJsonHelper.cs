using RecruitJr.Core.Classes;

namespace RecruitJr.Core.Interfaces.Helpers
{
    public interface IJsonHelper
    {
        Result<string> Serialize<T>(T input);
        Result<T> Deserialize<T> (string input);
    }
}