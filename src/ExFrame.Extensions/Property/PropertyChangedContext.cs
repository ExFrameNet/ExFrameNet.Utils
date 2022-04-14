using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace ExFrame.Extensions.Property
{
    public class PropertyChangedContext<T, TProperty> : PropertyContext<T, TProperty>
        where T : class, INotifyPropertyChanged
    {
        internal PropertyChangedContext(T classInstance, string propertyName, Func<T, TProperty> propertyReader) 
            : base(classInstance, propertyName, propertyReader)
        {
        }

        internal PropertyChangedContext(T classInstance, Expression<Func<T, TProperty>> propertySelector)
            : base(classInstance, propertySelector)
        {
        }

        internal PropertyChangedContext(PropertyContext<T,TProperty> property)
            : base(property)
        {

        }
    }
}