using System.Globalization;
using System.Windows;
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

        private void CulturesListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selected = CulturesListView.SelectedItem;

            if (selected == null)
                return;

            if (selected is CultureInfo info) 
                _vm.CurrentCulture = info;
        }
    }
}