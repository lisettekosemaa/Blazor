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
}