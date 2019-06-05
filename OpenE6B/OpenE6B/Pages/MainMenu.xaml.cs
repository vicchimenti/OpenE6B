using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenE6B.Classes;
using OpenE6B.ViewModels;

namespace OpenE6B.Pages
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    [ExcludeFromCodeCoverage]
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void BtnMetar_Click(object sender, RoutedEventArgs e)
        {
            var frame = UIHelper.FindVisualParent<Frame>(this);
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            var metarPage = new MetarTaf(new MetarTafViewModel());
            frame.Content = metarPage;


        }

        private void BtnIsa_Click(object sender, RoutedEventArgs e)
        {
            var frame = UIHelper.FindVisualParent<Frame>(this);
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            var isaPage = new ISADevPage(new IsaDevViewModel());
            frame.Content = isaPage;
        }

        private void BtnWindComp_Click(object sender, RoutedEventArgs e)
        {
            var frame = UIHelper.FindVisualParent<Frame>(this);
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            var windPage = new WindCompPage(new WindCompViewModel());
            frame.Content = windPage;
        }
    }
}
