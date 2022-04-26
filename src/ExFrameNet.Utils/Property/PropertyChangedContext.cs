using System.ComponentModel;
using System.Linq.Expressions;

namespace ExFrameNet.Utils.Property;

public class PropertyChangedContext<T, TProperty> : PropertyContext<T, TProperty>
    where T : class, INotifyPropertyChanged
{
    internal List<Action<T, TProperty>> _changedActions = new();

    internal PropertyChangedContext(T classInstance, Expression<Func<T, TProperty>> propertySelector)
        : base(classInstance, propertySelector)
    {
    }

    internal PropertyChangedContext(T classInstance, string propertyName, Func<T, TProperty> propertyReader)
        : base(classInstance, propertyName, propertyReader)
    {
    }

    internal PropertyChangedContext(PropertyContext<T, TProperty> property)
        : base(property)
    {

    }

    public PropertyChangedContext(PropertyChangedContext<T, TProperty> ctx)
        : base(ctx)
    {
        _changedActions = ctx._changedActions;
    }
}
