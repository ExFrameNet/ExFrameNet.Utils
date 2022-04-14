using System;
using System.Linq.Expressions;
using exFrame.Extensions.Property.Internal;

namespace exFrame.Extensions.Property
{
    public static partial class PropertyExtensions
    {
        public static IProperty<T, TProperty> Property<T, TProperty>(this T classInstance, Expression<Func<T, TProperty>> propertySelector)
            where T : class
            => new PropertyInternal<T, TProperty>(classInstance, propertySelector);
    }
}
