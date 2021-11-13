using System;
using System.Collections.Generic;
using System.IO;
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

namespace PastePngFromClipboardWithAlpha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PasteByGetImage(object sender, RoutedEventArgs e)
        {
            var source = Clipboard.GetImage();
            image.Source = source;
        }

        private void PasteByGetData(object sender, RoutedEventArgs e)
        {
            var dataObject = Clipboard.GetDataObject();
            if (dataObject?.GetFormats()?.Contains("PNG") is not true) return;

            using var stream = (MemoryStream)dataObject.GetData("PNG");

            var source = new BitmapImage();
            source.BeginInit();
            source.StreamSource = stream;
            source.CacheOption = BitmapCacheOption.OnLoad;
            source.EndInit();

            image.Source = source;
        }
    }
}
