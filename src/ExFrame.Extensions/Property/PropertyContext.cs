using ExFrame.Extensions.System;
using System;
using System.Linq.Expressions;

namespace ExFrame.Extensions.Property
{
    public class PropertyContext<T, TProperty>
        where T : class
    {
        public string Name { get; }
        public T ClassInstance { get; }
        public TProperty Value => PropertyReader(ClassInstance);
        internal Func<T, TProperty> PropertyReader { get; }

        internal PropertyContext(T classInstance, Expression<Func<T, TProperty>> propertySelector)
            : this(classInstance, propertySelector.GetPropertyName(), propertySelector.Compile())
        {
        }

        internal PropertyContext(T classInstance, string propertyName, Func<T, TProperty> propertyReader)
        {
            ClassInstance = classInstance;
            Name = propertyName;
            PropertyReader = propertyReader;
        }

        internal PropertyContext(PropertyContext<T,TProperty> property)
        {
            Name = property.Name;
            ClassInstance = property.ClassInstance;
            PropertyReader = property.PropertyReader;
        }
    }
}