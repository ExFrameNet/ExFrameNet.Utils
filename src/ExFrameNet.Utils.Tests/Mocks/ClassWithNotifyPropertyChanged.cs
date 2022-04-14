using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExFrameNet.Utils.Tests.Mocks
{
    internal class ClassWithNotifyPropertyChanged : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                    return;

                _name = value;
                OnPropertyChanged();
            }
        }

        private object _data;
        public object Data
        {
            get => _data;
            set
            {
                if (_data == value)
                    return;

                _data = value;
                OnPropertyChanged();
            }
        }

        public bool Changed { get; private set; } = false;


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void CalledWhenChanged(string name)
        {
            Changed = true;
        }
    }
}
