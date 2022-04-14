using ExFrame.Extensions.Property;
using ExFrame.Extensions.System;
using System;
using System.Linq.Expressions;

namespace ExFrame.Extensions.Property.Internal
{
    internal class PropertyInternal<T, TProperty> : IProperty<T, TProperty>
        where T : class
    {
        public string Name { get; }
        public T ClassInstance { get; }
        public TProperty Value => PropertyReader(ClassInstance);
        Func<T, TProperty> IProperty<T, TProperty>.PropertyReader => PropertyReader;

        internal Func<T, TProperty> PropertyReader { get; }


        public PropertyInternal(T classInstance, Expression<Func<T, TProperty>> propertySelector)
            : this(classInstance, propertySelector.GetPropertyName(), propertySelector.Compile())
        {
        }

        public PropertyInternal(T classInstance, string propertyName, Func<T, TProperty> propertyReader)
        {
            ClassInstance = classInstance;
            Name = propertyName;
            PropertyReader = propertyReader;
        }
    }
}
