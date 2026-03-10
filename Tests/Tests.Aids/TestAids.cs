using System.Reflection;

namespace Abc.Tests.Aids;

public abstract class TestAids<TClass> where TClass : class, new ()
{
    protected TClass obj;
    protected const BindingFlags PublicDeclared = BindingFlags.Public
                                                  | BindingFlags.Instance
                                                  | BindingFlags.DeclaredOnly
                                                  | BindingFlags.Static;
    protected static IEnumerable<string> GetProperties()
        => Abc.Aids.GetType.PropertyNames<TClass>(PublicDeclared);
    protected static IEnumerable<string> GetMethods()
        => Abc.Aids.GetType.MethodNames<TClass>(PublicDeclared, false);

    protected void IsProperty<T>(string name)
    {
        var p = typeof(TClass).GetProperty(name);
        Assert.IsNotNull(p, NoProperty(name));
        Assert.AreEqual(typeof(T), p.PropertyType, WrongType<T>(name, p));
    }
    private static string WrongType<T>(string name, PropertyInfo p) 
        => $"Property '{name}' in class '{typeof(TClass).Name}' is of " +
           $"type '{p.PropertyType.Name}' instead of '{typeof(T).Name}'.";
    private static string NoProperty(string name) 
        => $"Class '{typeof(TClass).Name}' does not have a public property named '{name}'.";
}