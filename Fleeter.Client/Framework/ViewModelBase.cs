using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fleeter.Client.Framework
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Set<T>(ref T container, T value, [CallerMemberName] string propertyName = null)
        {
            container = value;
            RaisePropertyChanged(propertyName);
        }
    }
}
