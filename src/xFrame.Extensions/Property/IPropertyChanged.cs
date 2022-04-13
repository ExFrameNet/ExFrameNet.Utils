using System.ComponentModel;

namespace xFrame.Extensions.Property
{
    public interface IPropertyChanged<T, TProperty> : IProperty<T, TProperty>
        where T : class, INotifyPropertyChanged
    {

    }
}