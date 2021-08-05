using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace WindowsCulturesViewer.Models
{
    public class Culture
    {
        public ObservableCollection<Culture> SubCultures { get; } = new ObservableCollection<Culture>();

        public CultureInfo CultureInfo { get; }

        public Culture(CultureInfo info)
        {
            CultureInfo = info;
        }

        public Culture(CultureInfo info, List<CultureInfo> subCulture) : this(info)
        {
            var sorted = new SortedList<string, CultureInfo>();
            subCulture.ForEach(c => sorted.Add(c.Name, c));

            sorted.Values.ToList().ForEach(c => SubCultures.Add(new Culture(c)));
        }
    }
}