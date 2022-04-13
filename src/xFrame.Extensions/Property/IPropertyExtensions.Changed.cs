﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using xFrame.Extensions.Property.Internal;

namespace xFrame.Extensions.Property
{
    public static class IPropertyExtensions
    {
        public static IPropertyChanged<T,TProperty> Changed<T,TProperty>(this IProperty<T,TProperty> property)
            where T : class, INotifyPropertyChanged
        {
            return new PropertyChangedInternal<T,TProperty>(property);
        }

        public static IPropertyChanged<T,TProperty> Subscribe<T,TProperty>(this IPropertyChanged<T,TProperty> property, Action<TProperty> callBack)
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