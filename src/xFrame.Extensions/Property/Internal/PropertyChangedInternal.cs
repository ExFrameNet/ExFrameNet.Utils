using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace xFrame.Extensions.Property.Internal
{
    internal class PropertyChangedInternal<T, TProperty> : PropertyInternal<T, TProperty>, IPropertyChanged<T, TProperty>
        where T : class, INotifyPropertyChanged
    {
        public PropertyChangedInternal(T classInstance, Expression<Func<T, TProperty>> propertySelector) : base(classInstance, propertySelector)
        {
        }

        public PropertyChangedInternal(IProperty<T,TProperty> property) 
            : base(property.ClassInstance, property.Name ,property.PropertyReader)
        {

        }
    }
}
