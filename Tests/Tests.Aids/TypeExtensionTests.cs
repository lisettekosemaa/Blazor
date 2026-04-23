using Abc.Aids;

namespace Abc.Tests.Aids
{
    [TestClass] public class TypeExtensionTests : TestAids
    {
        [TestInitialize] public void TestInitialize() => type = typeof(TypeExtension);
        [TestMethod] public void IsBoolTest()
        {
            Assert.IsTrue(TypeExtension.IsBool(typeof(bool)));
            Assert.IsFalse(TypeExtension.IsBool(typeof(string)));
            Assert.IsTrue(typeof(bool).IsBool());
        }
        [TestMethod] public void IsBoolNullableTest()
        {
            Assert.IsTrue(TypeExtension.IsBool(typeof(bool?)));
        }
        [TestMethod] public void IsDateTest() 
        {
            Assert.IsTrue(TypeExtension.IsDate(typeof(DateTime)));
            Assert.IsTrue(TypeExtension.IsDate(typeof(DateOnly)));
            Assert.IsFalse(TypeExtension.IsDate(typeof(string)));
            Assert.IsFalse(TypeExtension.IsDate(null));
        }
        [TestMethod] public void IsStringTest()
        {
            Assert.IsTrue(TypeExtension.IsString(typeof(string)));
            Assert.IsFalse(TypeExtension.IsString(typeof(int)));
            Assert.IsFalse(TypeExtension.IsString(null));
        }

        [DataRow(typeof(byte))]
        [DataRow(typeof(byte?))]
        [DataRow(typeof(sbyte))]
        [DataRow(typeof(sbyte?))]
        [DataRow(typeof(short))]
        [DataRow(typeof(short?))]
        [DataRow(typeof(ushort))]
        [DataRow(typeof(ushort?))]
        [DataRow(typeof(int))]
        [DataRow(typeof(int?))]
        [DataRow(typeof(uint))]
        [DataRow(typeof(uint?))]
        [DataRow(typeof(long))]
        [DataRow(typeof(long?))]
        [DataRow(typeof(ulong))]
        [DataRow(typeof(ulong?))]
        [DataRow(typeof(float))]
        [DataRow(typeof(float?))]
        [DataRow(typeof(double))]
        [DataRow(typeof(double?))]
        [DataRow(typeof(decimal))]
        [DataRow(typeof(decimal?))]
        [TestMethod] public void IsNumericTest(Type t)
        {
            Assert.IsTrue(TypeExtension.IsNumeric(t));
            Assert.IsTrue(t.IsNumeric());
        }
        
        [DataRow(typeof(string))]
        [DataRow(typeof(bool))]
        [DataRow(typeof(DateTime))]
        [DataRow(typeof(DateOnly))]
        [DataRow(typeof(Guid))]
        [DataRow(typeof(object))]
        [DataRow(null)]
        [TestMethod] public void IsNumeric_NegativeTest(Type t)
        {
            Assert.IsFalse(TypeExtension.IsNumeric(t));
            if (t != null) Assert.IsFalse(t.IsNumeric());
        }
    }
}
