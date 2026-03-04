using System.Reflection;

namespace Abc.Tests.Data
{
    public abstract class BaseTests<TClass> where TClass : class, new()
    {
        private TClass obj;
        private const BindingFlags PublicDeclared = BindingFlags.Public 
                    | BindingFlags.Instance 
                    | BindingFlags.DeclaredOnly
                    | BindingFlags.Static;
        [TestInitialize] public void TestInitialize() => obj = new TClass();
        [TestMethod] public void CanCreateTest() => Assert.IsNotNull(obj);
        [TestMethod] public void IsClassCorrectTest()
        {
            var className = typeof(TClass).Name;
            var testClassName = GetType().Name;
            Assert.AreEqual(testClassName.Replace("Tests", ""), className);
        }
        [TestMethod] public void IsClassTestedTest()
        {
            var testMethods = GetType().GetMethods().Select(x => x.Name);
            var membersToTest = GetProperties().Concat(GetMethods());
            foreach (var m in membersToTest)
            {
                if (!testMethods.Contains(m + "Test"))
                    Assert.Inconclusive($"{m} is not tested!");
            }
        }

        private static IEnumerable<string> GetProperties() =>
            typeof(TClass).GetProperties(PublicDeclared)
                .Select(i => i.Name);
        public static IEnumerable<string> GetMethods() => Array.FindAll(
                typeof(TClass).GetMethods(PublicDeclared), 
                i => !i.IsSpecialName)  
                .Select(i => i.Name);
    }
}
