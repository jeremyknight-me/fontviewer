using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace FontViewer
{
    internal class FontViewerViewModel : INotifyPropertyChanged
    {
        private IEnumerable<FontFamily> fonts;

        private FontStyle style;

        private FontWeight weight;

        public FontViewerViewModel()
        {
            this.style = FontStyles.Normal;
            this.weight = FontWeights.Normal;
            this.fonts = System.Windows.Media.Fonts.SystemFontFamilies.OrderBy(x => x.Source);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<FontFamily> Fonts
        {
            get { return this.fonts; }
            set
            {
                this.fonts = value;
                this.NotifyPropertyChanged("Fonts");
            }
        }

        public FontStyle SelectedFontStyle
        {
            get { return this.style; }
            set
            {
                this.style = value;
                this.NotifyPropertyChanged("SelectedFontStyle");
            }
        }

        public FontWeight SelectedFontWeight
        {
            get { return this.weight; }
            set
            {
                this.weight = value;
                this.NotifyPropertyChanged("SelectedFontWeight");
            }
        }

        public void FilterFonts(string filter)
        {
            string loweredFilter = filter.ToLower();

            if (string.IsNullOrEmpty(filter))
            {
                this.Fonts = System.Windows.Media.Fonts.SystemFontFamilies
                    .AsParallel()
                    .OrderBy(x => x.Source);
            }
            else
            {
                this.Fonts =
                    System.Windows.Media.Fonts.SystemFontFamilies
                        .AsParallel()
                        .Where(x => x.Source.ToLower().Contains(loweredFilter))
                        .OrderBy(x => x.Source);
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
