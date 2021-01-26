using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FontViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal FontViewerViewModel ViewModel
        {
            get { return this.DataContext as FontViewerViewModel; }
        }

        public MainWindow()
        {
            this.DataContext = new FontViewerViewModel();
            InitializeComponent();
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.SelectedFontWeight = FontWeights.Bold;
        }

        private void ItalicsButton_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.SelectedFontStyle = FontStyles.Italic;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.ViewModel.SelectedFontStyle = FontStyles.Normal;
            this.ViewModel.SelectedFontWeight = FontWeights.Normal;
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                string filter = (sender as TextBox).Text;
                this.ViewModel.FilterFonts(filter);
            }
        }
    }
}
