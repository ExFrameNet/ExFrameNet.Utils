namespace xFrame.Extensions.Property
{
    public interface IProperty<T, TProperty>
    {
        string Name { get; }
        T ClassInstance { get; }
        TProperty Value { get; }
    }
}