using System.ComponentModel;

namespace ExFrame.Extensions.Property
{
    public interface IPropertyChanged<T, TProperty> : IProperty<T, TProperty>
        where T : class, INotifyPropertyChanged
    {

    }
}