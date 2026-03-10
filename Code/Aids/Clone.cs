using System.Reflection;

namespace Abc.Aids
{
    public static class Clone
    {
        public static TClass Object<TClass>(TClass obj)
            where TClass : class, new() => (TClass)ClonedObject(obj);

        private const BindingFlags PublicInstance = BindingFlags.Public | BindingFlags.Instance;
        private static object ClonedObject(object obj)
        {
            if (obj == null) return null;
            var t = obj.GetType();
            var o = Activator.CreateInstance(t);
            var props = t.GetProperties(PublicInstance);
            Copy(obj, o, props);
            return o;
        }
        public static void Copy(object from, object to, PropertyInfo[] props)
        {
            foreach (var p in props)
            {
                if (!p.CanRead || !p.CanWrite) continue;
                var v = p.GetValue(from);
                if (v != null && IsClass(p))
                    v = ClonedObject(v);
                p.SetValue(to, v);
            }
        }
        private static bool IsClass(PropertyInfo p) 
            => p.PropertyType.IsClass && p.PropertyType != typeof(string);
    }
}
