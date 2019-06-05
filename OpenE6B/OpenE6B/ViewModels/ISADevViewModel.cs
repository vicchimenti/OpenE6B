using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
// using OpenE6B.Annotations;
using OpenE6B.Classes;
using OpenE6B.Pages;

namespace OpenE6B.ViewModels
{
    public class IsaDevViewModel : INotifyPropertyChanged
    {
        private int _temperatureC;
        private int _altitude;
        private string _result;
        //Displayed result of the calculation
        [ExcludeFromCodeCoverage]
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

        //Altitude value for which ISA Deviation is calculated.
        public int Altitude
        {
            get { return _altitude; }
            set
            {
                if (value == _altitude) return;
                _altitude = value;
                OnPropertyChanged();
            }
        }

        //Temperate value at given altitude for which ISA Deviation is calculated.
        public int TemperatureC
        {
            get { return _temperatureC; }
            set
            {
                if (value == _temperatureC) return;
                _temperatureC = value;
                OnPropertyChanged();
            }
        }

        [ExcludeFromCodeCoverage]
        public ICommand CalculateDeviationCommand { get; set; }
        [ExcludeFromCodeCoverage]
        public ICommand MainMenuCommand { get; set; }

        //Contructor
        public IsaDevViewModel()
        {
            CalculateDeviationCommand = new RelayCommand(Calculate,CanCalculate);
            MainMenuCommand = new RelayCommand(GoToMainMenu);
        }

        public bool CanCalculate(object param)
        {
            return true;
        }

        public void Calculate(object param)
        {
            Result = null;
            var calculator = new IsaDevCalculator();
            Result = calculator.GetDeviation(Altitude, TemperatureC);
        }

        [ExcludeFromCodeCoverage]
        public void GoToMainMenu(object param)
        {
            var frame = UIHelper.FindVisualParent<Frame>(param as DependencyObject);
            frame.Content = new MainMenu();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        [ExcludeFromCodeCoverage]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
