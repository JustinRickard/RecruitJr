using Common.Classes;
using Common.Enums;
using Common.Interfaces.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Common.Helpers
{
    public class JsonHelper : IJsonHelper
    {
        public Result<string> Serialize<T> (T input) {
            try {
                var result = JsonConvert.SerializeObject(input, new StringEnumConverter());
                return Result<string>.Succeed(result);
            }
            catch {
                return Result<string>.Fail(ResultCode.CouldNotSerialize);
            }            
        }

        public Result<T> Deserialize<T> (string input) {
            try {
                var result = JsonConvert.DeserializeObject<T>(input);
                return Result<T>.Succeed(result);
            }
            catch {
                return Result<T>.Fail(ResultCode.CouldNotDeserialize);
            }
        }
    }
}