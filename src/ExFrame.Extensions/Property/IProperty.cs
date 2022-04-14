using System;

namespace ExFrame.Extensions.Property
{
    public interface IProperty<T, TProperty>
        where T : class
    {
        string Name { get; }
        T ClassInstance { get; }
        TProperty Value { get; }
        internal Func<T, TProperty> PropertyReader { get; }
    }
}