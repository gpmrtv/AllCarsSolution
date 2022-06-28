using Newtonsoft.Json;
using System.Reflection;

namespace AllCar.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static string GetDifferences<T>(this T currentObj, T newObj)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            T diffObject = Activator.CreateInstance<T>();
            foreach (var property in properties)
            {
                object curValue = property.GetValue(currentObj);
                object newValue = property.GetValue(newObj);

                if (curValue is not null && !curValue.Equals(newValue))
                {
                    property.SetValue(diffObject, newValue);
                }
            }
            JsonSerializerSettings settings = new()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(diffObject, settings);
        }
    }
}
