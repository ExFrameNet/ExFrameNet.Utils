using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExFrameNet.Utils.Property
{
    public class AsyncPropertyChangedContext<T, TProperty> : PropertyContext<T, TProperty>
        where T : class, INotifyPropertyChanged
    {
        internal List<Func<T, TProperty, Task>> ChangedActions = new List<Func<T, TProperty, Task>>();

        internal AsyncPropertyChangedContext(T classInstance, Expression<Func<T, TProperty>> propertySelector)
            : base(classInstance, propertySelector)
        {
        }

        internal AsyncPropertyChangedContext(PropertyContext<T, TProperty> property)
            : base(property)
        {

        }
    }
}