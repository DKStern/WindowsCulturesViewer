using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WindowsCulturesViewer.Models;
using WindowsCulturesViewer.ViewModels;

namespace WindowsCulturesViewer.Views
{
    public partial class MainWindow : Window
    {
        private WCVViewModel _vm;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = new WCVViewModel();
            DataContext = _vm;
        }

        private void CulturesTree_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (CulturesTree.SelectedItem is Culture item)
                _vm.CurrentCulture = item.CultureInfo;
        }
    }
}