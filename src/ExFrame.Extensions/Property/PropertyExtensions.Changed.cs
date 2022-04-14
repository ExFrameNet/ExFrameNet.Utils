using System;
using System.ComponentModel;

namespace ExFrame.Extensions.Property
{
    public static class IPropertyExtensions
    {
        public static PropertyChanged<T, TProperty> Changed<T, TProperty>(this Property<T, TProperty> property)
            where T : class, INotifyPropertyChanged
        {
            return new PropertyChanged<T, TProperty>(property);
        }

        public static PropertyChanged<T, TProperty> Subscribe<T, TProperty>(this PropertyChanged<T, TProperty> property, Action<TProperty> callBack)
            where T : class, INotifyPropertyChanged
        {
            property.ClassInstance.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == property.Name)
                    callBack(property.Value);
            };
            return property;
        }
    }
}
