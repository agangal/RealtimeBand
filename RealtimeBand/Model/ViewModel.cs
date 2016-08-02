using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeBand.Model
{
    [DataContract]
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChangedEventHandler pceh = PropertyChanged;
            if (pceh != null)
            {
                pceh(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public void NotifyPropertyChanged(params string[] changedProperties)
        {
            if (changedProperties != null)
            {
                foreach (string property in changedProperties)
                {
                    OnPropertyChanged(property);
                }
            }
        }

        protected virtual bool SetValue<T>(ref T target, T value, params string[] changedProperties)
        {
            if(Object.Equals(target, value))
            {
                return false;
            }
            target = value;
            foreach (string property in changedProperties)
            {
                OnPropertyChanged(property);
            }
            return true;
        }
    }
}
