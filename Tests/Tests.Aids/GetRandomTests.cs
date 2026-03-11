using Abc.Aids;

namespace Abc.Tests.Aids
{
    [TestClass] public sealed class GetRandomTests
    {
        private const byte min = byte.MinValue;
        private const byte max = byte.MaxValue;
        [TestMethod] public void Int32Test() 
            => Assert.AreNotEqual(GetRandom.Int32(min, max), GetRandom.Int32(min, max));
        [TestMethod] public void Int64Test() 
            => Assert.AreNotEqual(GetRandom.Int64(min, max), GetRandom.Int64(min, max));
        [TestMethod] public void DoubleTest() 
            => Assert.AreNotEqual(GetRandom.Double(min, max), GetRandom.Double(min, max));
        [TestMethod] public void Int8Test() 
            => Assert.AreNotEqual(GetRandom.Int8(min, max), GetRandom.Int8(min, max));
        [TestMethod] public void Int16Test() 
            => Assert.AreNotEqual(GetRandom.Int16(min, max), GetRandom.Int16(min, max));
    }
}
