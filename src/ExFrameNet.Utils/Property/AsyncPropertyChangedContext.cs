using System.ComponentModel;
using System.Linq.Expressions;

namespace ExFrameNet.Utils.Property;

public class AsyncPropertyChangedContext<T, TProperty> : PropertyContext<T, TProperty>
    where T : class, INotifyPropertyChanged
{
    internal List<Func<T, TProperty, Task>> _changedActions = new List<Func<T, TProperty, Task>>();

    internal AsyncPropertyChangedContext(T classInstance, Expression<Func<T, TProperty>> propertySelector)
        : base(classInstance, propertySelector)
    {
    }

    internal AsyncPropertyChangedContext(PropertyContext<T, TProperty> property)
        : base(property)
    {

    }
}
