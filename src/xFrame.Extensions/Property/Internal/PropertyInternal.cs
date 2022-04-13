using System;
using System.Linq.Expressions;
using xFrame.Extensions.System;

namespace xFrame.Extensions.Property.Internal
{
    internal class PropertyInternal<T, TProperty> : IProperty<T, TProperty>
    {
        public string Name { get; }
        public T ClassInstance { get; }
        public TProperty Value => PropertyReader(ClassInstance);
        public Func<T,TProperty> PropertyReader { get; }


        public PropertyInternal(T classInstance, Expression<Func<T,TProperty>> propertySelector)
        {
            ClassInstance = classInstance;
            Name = propertySelector.GetPropertyName();
            PropertyReader = propertySelector.Compile();
        }
    }
}
