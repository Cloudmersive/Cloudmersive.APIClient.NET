using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
using CloudmersiveClient.Audit;
using Microsoft.Win32;
using Newtonsoft.Json;

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

        private void btnRecognizeImage_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (! dlg.ShowDialog().Value )
                return;

            string path = dlg.FileName;

            ImageRecognitionAndProcessingClient client = new ImageRecognitionAndProcessingClient();

            var outcome = client.RecognizeImageToDescription(path);
            txtOutput.Text = outcome.BestOutcome.Description;
        }

        private void btnVirusScanFile_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (!dlg.ShowDialog().Value)
                return;

            string path = dlg.FileName;

            CloudmersiveVirusScanClient client = new CloudmersiveVirusScanClient();

            var outcome = client.ScanFile(path);
            txtOutput.Text = JsonConvert.SerializeObject(outcome);
        }

        private void btnFindFace_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (!dlg.ShowDialog().Value)
                return;

            string path = dlg.FileName;

            // Process image

            ImageRecognitionAndProcessingClient client = new ImageRecognitionAndProcessingClient();

            System.Drawing.Image outcome = client.CropToFirstFace(path);


            var imageSourceConverter = new ImageSourceConverter();
            byte[] tempBitmap = BitmapToByte((System.Drawing.Bitmap) outcome);
            ImageSource image = (ImageSource)imageSourceConverter.ConvertFrom(tempBitmap);

            
            imgOutput.Source = image;

            // Log success

            CloudmersiveAuditClient client2 = new CloudmersiveAuditClient();

            AuditLogWriteRequest req = new AuditLogWriteRequest();
            req.AuditLogMessage = "Successfully processed image.";
            req.AuditLogReferenceIP = GetLocalIPAddress();
            req.AuditLogMeta = dlg.FileName;

            client2.WriteLogMessageFull(req);
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private byte[] BitmapToByte(System.Drawing.Bitmap bitmap)
        {
            byte[] byteArray;
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }


    }
}
