using ExFrame.Extensions.System;
using System;
using System.Linq.Expressions;

namespace ExFrame.Extensions.Property
{
    public class Property<T, TProperty>
        where T : class
    {
        public string Name { get; }
        public T ClassInstance { get; }
        public TProperty Value => PropertyReader(ClassInstance);
        internal Func<T, TProperty> PropertyReader { get; }

        internal Property(T classInstance, Expression<Func<T, TProperty>> propertySelector)
            : this(classInstance, propertySelector.GetPropertyName(), propertySelector.Compile())
        {
        }

        internal Property(T classInstance, string propertyName, Func<T, TProperty> propertyReader)
        {
            ClassInstance = classInstance;
            Name = propertyName;
            PropertyReader = propertyReader;
        }

        internal Property(Property<T,TProperty> property)
        {
            Name = property.Name;
            ClassInstance = property.ClassInstance;
            PropertyReader = property.PropertyReader;
        }
    }
}