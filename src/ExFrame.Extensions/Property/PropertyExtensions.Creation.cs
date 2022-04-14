using System;
using System.Linq.Expressions;

namespace ExFrame.Extensions.Property
{
    public static partial class PropertyExtensions
    {
        public static PropertyContext<T, TProperty> Property<T, TProperty>(this T classInstance, Expression<Func<T, TProperty>> propertySelector)
            where T : class
            => new PropertyContext<T, TProperty>(classInstance, propertySelector);

        public static PropertyContext<T,TTo> Transform<T,TProperty,TTo>(this PropertyContext<T,TProperty> ctx, Func<TProperty, TTo> transformer)
            where T : class
        {
            TTo reader(T x) => transformer(ctx.PropertyReader(x));
            return new PropertyContext<T, TTo>(ctx.ClassInstance, ctx.Name, reader);
        }
    }
}
