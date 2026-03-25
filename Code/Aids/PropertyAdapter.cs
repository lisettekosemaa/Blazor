using System.Reflection;

namespace Abc.Aids
{
    public interface IPropertyAdapter
    {
        PropertyInfo PropInfo { get; }
        public object Item { get; }
        object PropValue { get; }
        public Type ItemType { get; }
        public Type PropType { get; }
        public Type UnderlyingType { get; }
        void SetValue(object value);
    }

    public sealed class PropertyAdapter(object item, string propertyName) : IPropertyAdapter
    {
        public PropertyAdapter() : this(null, null) { }
        public PropertyInfo PropInfo => ItemType?.GetProperty(propertyName);
        public object Item => item;
        public object PropValue => PropInfo?.GetValue(item);
        public Type ItemType => item?.GetType();
        public Type PropType => PropInfo?.PropertyType;
        public Type UnderlyingType => Nullable.GetUnderlyingType(PropType) ?? PropType;
        public void SetValue(object value) => PropInfo?.SetValue(item, value);
    }
}
