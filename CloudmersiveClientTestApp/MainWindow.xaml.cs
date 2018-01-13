using System;
using System.Collections.Generic;
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
using CloudmersiveClient;

namespace CloudmersiveClientTestApp
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CloudmersiveNlpApiClient client = new CloudmersiveNlpApiClient();

            txtOutput.Text = client.PartOfSpeechTag_String(txtInput.Text);
        }

        private void btnParse_Click(object sender, RoutedEventArgs e)
        {
            CloudmersiveNlpApiClient client = new CloudmersiveNlpApiClient();

            txtOutput.Text = client.Parse_String(txtInput.Text);
        }

        private void btnEntities_Click(object sender, RoutedEventArgs e)
        {
            CloudmersiveNlpApiClient client = new CloudmersiveNlpApiClient();

            txtOutput.Text = client.ExtractEntities_String(txtInput.Text);
        }

        private void btnGeolocate_Click(object sender, RoutedEventArgs e)
        {
            CloudmersiveValidationApiClient client = new CloudmersiveValidationApiClient();

            var result = client.GeolocateIP(txtIP.Text);
            txtOutput.Text = result.City + ", " + result.CountryName;
        }

        private void btnKeyUsage_Click(object sender, RoutedEventArgs e)
        {
            CloudmersiveValidationApiClient client = new CloudmersiveValidationApiClient();

            txtOutput.Text = client.GetApikeyUsage().ToString();
        }
    }
}
