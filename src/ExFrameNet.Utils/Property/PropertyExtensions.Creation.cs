using System.ComponentModel;
using System.Linq.Expressions;

namespace ExFrameNet.Utils.Property;

public static partial class PropertyExtensions
{
    public static PropertyContext<T, TProperty> Property<T, TProperty>(this T classInstance, Expression<Func<T, TProperty>> propertySelector)
        where T : class
    {
        return new PropertyContext<T, TProperty>(classInstance, propertySelector);
    }

    public static PropertyContext<T, TTo> Transform<T, TProperty, TTo>(this PropertyContext<T, TProperty> ctx, Func<TProperty, TTo> transformer)
        where T : class
    {
        TTo reader(T x) => transformer(ctx.PropertyReader(x));
        return new PropertyContext<T, TTo>(ctx.ClassInstance, ctx.Name, reader);
    }


    public static PropertyChangedContext<T, TTo> Transform<T, TProperty, TTo>(this PropertyChangedContext<T, TProperty> ctx, Func<TProperty, TTo> transformer)
        where T : class, INotifyPropertyChanged
    {
        TTo reader(T x) => transformer(ctx.PropertyReader(x));
        return new PropertyChangedContext<T, TTo>(ctx.ClassInstance, ctx.Name, reader);
    }
}
