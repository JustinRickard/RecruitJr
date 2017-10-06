using Microsoft.AspNetCore.Identity;

namespace RecruitJr.Core.Security
{
    public class LookupNormalizer : ILookupNormalizer
    {
        string ILookupNormalizer.Normalize(string key)
        {
            return key.ToUpper();
        }
    }
}