using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace FontViewer;

internal class FontViewerViewModel : INotifyPropertyChanged
{
    private IEnumerable<FontFamily> _fonts;
    private FontStyle _style;
    private FontWeight _weight;

    public FontViewerViewModel()
    {
        _style = FontStyles.Normal;
        _weight = FontWeights.Normal;
        _fonts = System.Windows.Media.Fonts.SystemFontFamilies.OrderBy(x => x.Source);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public IEnumerable<FontFamily> Fonts
    {
        get { return _fonts; }
        set
        {
            _fonts = value;
            NotifyPropertyChanged("Fonts");
        }
    }

    public FontStyle SelectedFontStyle
    {
        get { return _style; }
        set
        {
            _style = value;
            NotifyPropertyChanged("SelectedFontStyle");
        }
    }

    public FontWeight SelectedFontWeight
    {
        get { return _weight; }
        set
        {
            _weight = value;
            NotifyPropertyChanged("SelectedFontWeight");
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
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
