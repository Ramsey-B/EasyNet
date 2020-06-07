using Newtonsoft.Json;

namespace EasyNet.Extensions.ObjectExtensions
{
    public static class JsonExtensions
    {
        public static string SerializeToJson(this object obj)
        {
            if (obj == null) return null;
            if (obj is string) return obj as string;
            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeJson<T>(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return default(T);
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
