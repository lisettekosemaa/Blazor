using System.Reflection;

namespace Abc.Tests.Aids;

public abstract class TestAids<TClass> : TestAids where TClass : class, new ()
{
    protected TClass obj;
    [TestInitialize] public virtual void TestInitialize() => type = typeof(TClass);

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
public abstract class TestAids
{
    protected Type type { get; set; }
    [TestMethod] public void IsClassCorrectTest() {
        var className = type?.Name;
        var testClassName = GetType().Name;
        Assert.AreEqual(testClassName.Replace("Tests", ""), className);
    }
    public void areEqual<T>(T expected, T actual) => Assert.AreEqual(expected, actual);
    public void areSame(object expected, object actual) => Assert.AreSame(expected, actual);
}