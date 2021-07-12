using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using WindowsCulturesViewer.Annotations;

namespace WindowsCulturesViewer.ViewModels
{
    public class WCVViewModel : INotifyPropertyChanged
    {
        private List<CultureInfo> cultures;

        private CultureInfo currentCulture;
        
        public ObservableCollection<CultureInfo> Cultures { get; set; } = new ObservableCollection<CultureInfo>();

        public WCVViewModel()
        {
            cultures = CultureInfo.GetCultures(CultureTypes.AllCultures).ToList();
            SynchronizeCultures();
        }

        public CultureInfo CurrentCulture
        {
            get => currentCulture;
            set
            {
                if (Equals(currentCulture, value))
                    return;

                currentCulture = value;
                OnPropertyChanged(nameof(CurrentCulture));
            }
        }

        private void SynchronizeCultures()
        {
            Cultures.Clear();
            cultures.Sort((c1, c2) => string.Compare(c1.Name, c2.Name));
            cultures.ForEach(x => Cultures.Add(x));
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