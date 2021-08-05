using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WindowsCulturesViewer.Annotations;

namespace WindowsCulturesViewer.ViewModels
{
    public class WCVViewModel : INotifyPropertyChanged
    {
        private readonly List<CultureInfo> _cultures;

        private CultureInfo _currentCulture;

        private const double c_numExample = 124536.20;

        public ObservableCollection<CultureInfo> Cultures { get; set; } = new ObservableCollection<CultureInfo>();

        public string NumExample => c_numExample.ToString(_currentCulture);

        public string DateExample => DateTime.Now.ToString(_currentCulture);

        public string TimeExample => DateTime.Now.ToLocalTime().ToString(_currentCulture);

        public string CurrencyExample => c_numExample.ToString("C", _currentCulture);

        public WCVViewModel()
        {
            _cultures = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
            SynchronizeCultures();
        }

        public CultureInfo CurrentCulture
        {
            get => _currentCulture;
            set
            {
                if (Equals(_currentCulture, value))
                    return;

                _currentCulture = value;
                UpdateAll();
            }
        }

        private void SynchronizeCultures()
        {
            Cultures.Clear();
            _cultures.Sort((c1, c2) => string.Compare(c1.EnglishName, c2.EnglishName));
            _cultures.ForEach(x => Cultures.Add(x));
        }

        private async void SynchronizeCulturesAsunc()
        {
            await Task.Run(SynchronizeCultures);
        }

        private void UpdateAll()
        {
            OnPropertyChanged(nameof(CurrentCulture));
            OnPropertyChanged(nameof(NumExample));
            OnPropertyChanged(nameof(DateExample));
            OnPropertyChanged(nameof(TimeExample));
            OnPropertyChanged(nameof(CurrencyExample));
        }
        
        #region Интерфейс уведомлений

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}