using System.Reflection;

namespace CatalogFooball.Services.Enums
{
    public static class ReflectionEnum
    {
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            Type type = value.GetType();
            FieldInfo field = type.GetField(value.ToString());

            Attribute attr = Attribute.GetCustomAttribute(field, typeof(T), false);
            return (T)attr;
        }
    }
}
