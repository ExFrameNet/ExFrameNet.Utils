using System;
using System.Linq.Expressions;
using ExFrame.Extensions.Property.Internal;

namespace ExFrame.Extensions.Property
{
    public static partial class PropertyExtensions
    {
        public static IProperty<T, TProperty> Property<T, TProperty>(this T classInstance, Expression<Func<T, TProperty>> propertySelector)
            where T : class
            => new PropertyInternal<T, TProperty>(classInstance, propertySelector);
    }
}
