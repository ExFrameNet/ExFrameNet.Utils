using System;
using System.Linq.Expressions;
using xFrame.Extensions.Property.Internal;

namespace xFrame.Extensions.Property
{
    public static partial class PropertyExtensions
    {
        public static IProperty<T,TProperty> Property<T,TProperty>(this T classInstance, Expression<Func<T,TProperty>> propertySelector)
            => new PropertyInternal<T,TProperty>(classInstance, propertySelector);
    }
}
