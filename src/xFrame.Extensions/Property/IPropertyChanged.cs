﻿using System.ComponentModel;

namespace exFrame.Extensions.Property
{
    public interface IPropertyChanged<T, TProperty> : IProperty<T, TProperty>
        where T : class, INotifyPropertyChanged
    {

    }
}