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
    public class WindCompViewModel : INotifyPropertyChanged
    {
        public int RunwayHeading { get; set; }
        public int WindDirection { get; set; }
        public int WindSpeed { get; set; }
        public string Result { get; set; }

        public ICommand CalculateCommand { get; set; }
        public ICommand MainMenuCommand { get; set; }

        public WindCompViewModel()
        {
            CalculateCommand = new RelayCommand(CalculateWind);
            MainMenuCommand = new RelayCommand(GoToMainMenu);
        }

        public void GoToMainMenu(object param)
        {
            throw new NotImplementedException();
        }

        public void CalculateWind(object param)
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
