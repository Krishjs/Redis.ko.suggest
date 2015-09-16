using StackExchange.Redis;
using System;
using System.Linq;
using System.Reflection;

namespace Redis
{
    public static class RedisUtils
    {
        //Serialize in Redis format:
        public static HashEntry[] ToHashEntries(this object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            return properties.Where(property => IsPrimitive(property.PropertyType))
            .Select(property => new HashEntry(property.Name, property.GetValue(obj) == null ? string.Empty : property.GetValue(obj).ToString())).ToArray();
        }

        //Deserialize from Redis format
        public static T ConvertFromRedis<T>(this HashEntry[] hashEntries)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            object obj = Activator.CreateInstance(typeof(T));
            foreach (var property in properties)
            {
                Type t = property.PropertyType;
                if (IsPrimitive(t))
                {
                    HashEntry entry = hashEntries.FirstOrDefault(g => g.Name.ToString().Equals(property.Name));
                    if (entry.Equals(new HashEntry())) continue;
                    if (entry.Value.HasValue && !string.IsNullOrEmpty(entry.Value.ToString()))
                    {
                        property.SetValue(obj, Convert.ChangeType(entry.Value.ToString(), property.PropertyType));
                    }
                }
            }
            return (T)obj;
        }

        private static bool IsPrimitive(Type t)
        {
            return t.IsValueType || t.IsPrimitive || t == typeof(string);
        }
    }
}