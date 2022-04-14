using System;
using System.ComponentModel;

namespace ExFrame.Extensions.Property
{
    public static partial class PropertyExtensions
    {
        public static PropertyChangedContext<T, TProperty> OnChange<T, TProperty>(this PropertyContext<T, TProperty> property)
            where T : class, INotifyPropertyChanged
        {
            return new PropertyChangedContext<T, TProperty>(property);
        }

        public static PropertyChangedContext<T, TProperty> Subscribe<T, TProperty>(this PropertyChangedContext<T, TProperty> property, Action<TProperty> callBack)
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
