using System;
using System.Linq.Expressions;

namespace ExFrame.Extensions.Property
{
    public static partial class PropertyExtensions
    {
        public static Property<T, TProperty> Property<T, TProperty>(this T classInstance, Expression<Func<T, TProperty>> propertySelector)
            where T : class
            => new Property<T, TProperty>(classInstance, propertySelector);
    }
}
