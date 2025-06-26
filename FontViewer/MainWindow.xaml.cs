using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FontViewer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    internal FontViewerViewModel ViewModel
    {
        get { return DataContext as FontViewerViewModel; }
    }

    public MainWindow()
    {
        DataContext = new FontViewerViewModel();
        InitializeComponent();
    }

    private void BoldButton_Click(object sender, RoutedEventArgs e)
    {
        ViewModel.SelectedFontWeight = FontWeights.Bold;
    }

    private void ItalicsButton_Click(object sender, RoutedEventArgs e)
    {
        ViewModel.SelectedFontStyle = FontStyles.Italic;
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        ViewModel.SelectedFontStyle = FontStyles.Normal;
        ViewModel.SelectedFontWeight = FontWeights.Normal;
    }

    private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter || e.Key == Key.Return)
        {
            string filter = (sender as TextBox).Text;
            ViewModel.FilterFonts(filter);
        }
    }
}
