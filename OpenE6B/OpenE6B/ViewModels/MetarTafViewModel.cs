using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenE6B.Annotations;
using OpenE6B.Classes;

namespace OpenE6B.ViewModels
{
    public class MetarTafViewModel : INotifyPropertyChanged
    {
        private string _stationId;
        private string _rawMetarText;

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

        public string RawMetarText 
        {
            get { return _rawMetarText; }
            set
            {
                if (value == _rawMetarText) return;
                _rawMetarText = value;
                OnPropertyChanged();
            }
        }
        public Metar Metar { get; set; }
        public IAsyncCommand GetMetarCommand { get; set; }

        public MetarTafViewModel()
        {
            var retriever = new MetarRetriever();
            GetMetarCommand = new AsyncCommand<Metar>(() => retriever.GetMetar(StationId));
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
