using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace ExFrame.Extensions.Property
{
    public class PropertyChanged<T, TProperty> : Property<T, TProperty>
        where T : class, INotifyPropertyChanged
    {
        internal PropertyChanged(T classInstance, string propertyName, Func<T, TProperty> propertyReader) 
            : base(classInstance, propertyName, propertyReader)
        {
        }

        internal PropertyChanged(T classInstance, Expression<Func<T, TProperty>> propertySelector)
            : base(classInstance, propertySelector)
        {
        }

        internal PropertyChanged(Property<T,TProperty> property)
            : base(property)
        {

        }
    }
}