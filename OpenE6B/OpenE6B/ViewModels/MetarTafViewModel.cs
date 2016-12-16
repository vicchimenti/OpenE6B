using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenE6B.Annotations;

namespace OpenE6B.ViewModels
{
    public class MetarTafViewModel : INotifyPropertyChanged
    {
        private string _stationId;

        public string StationId 
        {
            get { return _stationId; }
            set
            {
                if (value == _stationId) return;
                _stationId = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
