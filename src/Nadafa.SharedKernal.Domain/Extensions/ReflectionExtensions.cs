using System.Reflection;

namespace Nadafa.SharedKernal.Domain.Extensions;

public static class ReflectionExtensions
{
    public static void SetPrivatePropertyValue<T>(this object obj, string propName, T val)
    {
        obj.GetType().GetField(propName, BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(obj, val);
    }

    public static List<Type> GetTypesThatInheritsFromAnInterface(this Assembly assembly, Type interfaceType)
    {
        Type interfaceType2 = interfaceType;
        return (from t in assembly.GetTypes()
                where t.GetInterfaces()
                    .Any((i) => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType2)
                select t).ToList();
    }
}