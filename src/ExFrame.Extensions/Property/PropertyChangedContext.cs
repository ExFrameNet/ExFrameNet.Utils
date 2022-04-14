using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace ExFrame.Extensions.Property
{
    public class PropertyChangedContext<T, TProperty> : PropertyContext<T, TProperty>
        where T : class, INotifyPropertyChanged
    {
        internal List<Action<T, TProperty>> ChangedActions = new List<Action<T, TProperty>>();

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