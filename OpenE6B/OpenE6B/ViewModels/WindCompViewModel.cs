using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using OpenE6B.Annotations;
using OpenE6B.Classes;
using OpenE6B.Pages;

namespace OpenE6B.ViewModels
{
    public class WindCompViewModel : INotifyPropertyChanged
    {
        private string _result;
        private int _windSpeed;
        private int _windDirection;
        private int _runwayHeading;

        public int RunwayHeading
        {
            get { return _runwayHeading; }
            set
            {
                if (value == _runwayHeading) return;
                _runwayHeading = value;
                OnPropertyChanged();
            }
        }

        public int WindDirection
        {
            get { return _windDirection; }
            set
            {
                if (value == _windDirection) return;
                _windDirection = value;
                OnPropertyChanged();
            }
        }

        public int WindSpeed
        {
            get { return _windSpeed; }
            set
            {
                if (value == _windSpeed) return;
                _windSpeed = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                if (value == _result) return;
                _result = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateCommand { get; set; }
        public ICommand MainMenuCommand { get; set; }

        public WindCompViewModel()
        {
            CalculateCommand = new RelayCommand(CalculateWind);
            MainMenuCommand = new RelayCommand(GoToMainMenu);
        }

        private void GoToMainMenu(object param)
        {
            var frame = UIHelper.FindVisualParent<Frame>(param as DependencyObject);
            frame.Content = new MainMenu();
        }

        private void CalculateWind(object param)
        {
            var calc = new WindComponentSolver();
            Result = calc.CalculateWind(WindSpeed, WindDirection, RunwayHeading);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
