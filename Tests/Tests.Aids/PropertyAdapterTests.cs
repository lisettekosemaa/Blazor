using System;
using System.Collections.Generic;
using System.Text;
using Abc.Aids;

namespace Abc.Tests.Aids
{
    [TestClass] public sealed class PropertyAdapterTests : BaseTests<PropertyAdapter>
    {
        private class TestClass {
            public string StringProp { get; set; }
            public int? IntProp { get; set; }
        }
        private TestClass item;
        private string propName = nameof(TestClass.IntProp);
        private PropertyAdapter objStr;
        [TestInitialize] public override void TestInitialize() {
            base.TestInitialize(); 
            item = new TestClass();
            obj = new PropertyAdapter(item, propName);
            objStr = new PropertyAdapter(item, nameof(TestClass.StringProp));
        }
        [TestMethod] public void ItemTypeTest() => areEqual(typeof(TestClass), obj.ItemType);
        [TestMethod] public void ItemTest() => areSame(item, obj.Item);
        [TestMethod] public void PropInfoTest() => areEqual(propName, obj.PropInfo.Name);
        [TestMethod] public void PropTypeTest() {
            areEqual(typeof(int?), obj.PropType);
            areEqual(typeof(string), objStr.PropType);
        }
        [TestMethod] public void UnderlyingTypeTest() {
            areEqual(typeof(int), obj.UnderlyingType);
            areEqual(typeof(string), objStr.UnderlyingType);
        }
        [TestMethod] public void PropValueTest() {
            areEqual(null, obj.PropValue);
            areEqual(null, objStr.PropValue);
        }
        [TestMethod] public void SetValueTest()
        {
            var i = GetRandom.Int32();
            var s = GetRandom.String();
            obj.SetValue(i);
            objStr.SetValue(s);
            areEqual(i, item.IntProp);
            areEqual(s, item.StringProp);
            areEqual(obj.PropValue, item.IntProp);
            areEqual(objStr.PropValue, item.StringProp);
        }
    }
}
