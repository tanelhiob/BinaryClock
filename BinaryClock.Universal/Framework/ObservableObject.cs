using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BinaryClock.Universal.Framework
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool RaisePropertyChanged<T>(ref T oldValue, ref T newValue, [CallerMemberName] string propertyName = null)
        {
            var casesForChange = new Predicate<(T oldValue, T newValue)>[]
            {
                x => x.oldValue == null && x.newValue != null,
                x => x.oldValue != null && x.newValue == null,
                x => !x.oldValue.Equals(x.newValue),
            };

            if (casesForChange.Any())
            {
                oldValue = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
