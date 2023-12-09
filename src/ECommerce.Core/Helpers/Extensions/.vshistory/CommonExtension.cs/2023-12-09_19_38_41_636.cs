

using Newtonsoft.Json;

namespace ECommerce.Core.Helpers.Extensions
{
    public static class CommonExtension
    {
        public static string ToJson(this object value)
        {
            if (value == null) return Null;

            try
            {
                string json = JsonConvert.SerializeObject(value);
                return json;
            }
            catch (Exception exception)
            {
                //log exception but dont throw one
                return Exception;
            }
        }
    }
}
