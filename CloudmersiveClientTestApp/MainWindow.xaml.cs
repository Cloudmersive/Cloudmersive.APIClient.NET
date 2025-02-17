﻿using System;
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
using CloudmersiveClient.Convert;
using CloudmersiveClient.ImageProcessing;
using CloudmersiveClient.Validation;
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

            var response = client.LocateFaces(File.ReadAllBytes(path));
            txtOutput.Text = JsonConvert.SerializeObject(response);


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

            CloudmersiveValidationApiClient valid = new CloudmersiveValidationApiClient();
            var geo = valid.GeolocateIP(req.AuditLogReferenceIP);
            req.AuditLogReferenceLocation = JsonConvert.SerializeObject(geo);

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

        private void btnNsfw_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (!dlg.ShowDialog().Value)
                return;

            string path = dlg.FileName;

            ImageRecognitionAndProcessingClient client = new ImageRecognitionAndProcessingClient();

            var outcome = client.NsfwClassification(path);
            txtOutput.Text = JsonConvert.SerializeObject(outcome);
        }

        private void btnToPDF_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (!dlg.ShowDialog().Value)
                return;

            string path = dlg.FileName;

            CloudmersiveConvertClient client = new CloudmersiveConvertClient();

            var outcome = client.Document_AutodetectToPdf(File.ReadAllBytes(dlg.FileName), System.IO.Path.GetFileName(dlg.FileName) );
            string output = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), System.IO.Path.GetFileNameWithoutExtension(dlg.FileName) + ".pdf");

            File.WriteAllBytes(output, outcome);
        }

        private void btnExcelToCSV_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (!dlg.ShowDialog().Value)
                return;

            string path = dlg.FileName;

            CloudmersiveConvertClient client = new CloudmersiveConvertClient();

            var outcome = client.Document_XlsxToCsv(File.ReadAllBytes(dlg.FileName));
            string output = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), System.IO.Path.GetFileNameWithoutExtension(dlg.FileName) + ".csv");

            File.WriteAllBytes(output, outcome);
        }

        private void btnCSVtoJSON_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (!dlg.ShowDialog().Value)
                return;

            string path = dlg.FileName;

            CloudmersiveConvertClient client = new CloudmersiveConvertClient();

            var outcome = client.CsvToJson(File.ReadAllBytes(dlg.FileName));
            string output = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(path), System.IO.Path.GetFileNameWithoutExtension(dlg.FileName) + ".json");

            File.WriteAllText(output, outcome);
        }

        private void btnScreenshot_Click(object sender, RoutedEventArgs e)
        {
            CloudmersiveConvertClient client = new CloudmersiveConvertClient();

            ScreenshotRequest req = new ScreenshotRequest();

            req.Url = "http://kaycircle.com";

            client.WebScreenshot(req);
        }

        private void btnTemplate_Click(object sender, RoutedEventArgs e)
        {
            CloudmersiveConvertClient client = new CloudmersiveConvertClient();

            HtmlTemplateApplicationRequest req = new HtmlTemplateApplicationRequest();
            req.HtmlTemplateUrl = "https://cloudmersive.com/email/welcome/welcome.html";

            HtmlTemplateOperation op = new HtmlTemplateOperation();
            op.Action = HtmlTemplateOperationAction.Replace;
            op.MatchAgsint = "#FirstName#";
            op.ReplaceWith = "Jon Smith";

            req.Operations = new HtmlTemplateOperation[] { op };
            

            var result = client.ApplyHtmlTemplate(req);

            Console.WriteLine(result.FinalHtml);
        }

        private void btnVATLookup_Click(object sender, RoutedEventArgs e)
        {
            CloudmersiveValidationApiClient client = new CloudmersiveValidationApiClient();

            VatLookupRequest req = new VatLookupRequest();
            req.VatCode = txtVAT.Text;

            VatLookupResponse response = client.VatLookup(req);

            txtOutput.Text = JsonConvert.SerializeObject(response);
        }

        private void btnIPLookup_Click(object sender, RoutedEventArgs e)
        {
            CloudmersiveValidationApiClient client = new CloudmersiveValidationApiClient();

            var response = client.GeolocateIP(txtVAT.Text);

            txtOutput.Text = JsonConvert.SerializeObject(response);
        }

        private void btnConvertToPainting_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (!dlg.ShowDialog().Value)
                return;

            string path = dlg.FileName;

            // Process image

            ImageRecognitionAndProcessingClient client = new ImageRecognitionAndProcessingClient();

            System.Drawing.Image outcome = client.ConvertToPainting( File.ReadAllBytes( path ));


            var imageSourceConverter = new ImageSourceConverter();
            byte[] tempBitmap = BitmapToByte((System.Drawing.Bitmap)outcome);
            ImageSource image = (ImageSource)imageSourceConverter.ConvertFrom(tempBitmap);


            imgOutput.Source = image;

            // Log success

            CloudmersiveAuditClient client2 = new CloudmersiveAuditClient();

            AuditLogWriteRequest req = new AuditLogWriteRequest();
            req.AuditLogMessage = "Successfully processed image.";
            req.AuditLogReferenceIP = GetLocalIPAddress();
            req.AuditLogMeta = dlg.FileName;

            CloudmersiveValidationApiClient valid = new CloudmersiveValidationApiClient();
            var geo = valid.GeolocateIP(req.AuditLogReferenceIP);
            req.AuditLogReferenceLocation = JsonConvert.SerializeObject(geo);

            client2.WriteLogMessageFull(req);
        }

        private void btnDetectObjects_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (!dlg.ShowDialog().Value)
                return;

            string path = dlg.FileName;

            // Process image

            var imageSourceConverter = new ImageSourceConverter();
            ImageRecognitionAndProcessingClient client = new ImageRecognitionAndProcessingClient();

            var objects = client.DetectObjects(File.ReadAllBytes(path));
            System.Drawing.Image outcome = System.Drawing.Image.FromFile(dlg.FileName);

            foreach (var obj in objects.Objects)
            {
                DrawRectangleRequest req = new DrawRectangleRequest();

                using (MemoryStream stream = new MemoryStream())
                {
                    outcome.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    req.BaseImageBytes = stream.ToArray();

                    DrawRectangleInstance instance = new DrawRectangleInstance();

                    instance.BorderColor = "red";
                    instance.BorderWidth = 5;
                    instance.X = obj.X;
                    instance.Y = obj.Y;
                    instance.Width = obj.Width;
                    instance.Height = obj.Height;

                    req.RectanglesToDraw = new DrawRectangleInstance[] { instance };

                    outcome = client.DrawRectangles(req);
                }
            }

            
            byte[] tempBitmap = BitmapToByte((System.Drawing.Bitmap)outcome);
            ImageSource image = (ImageSource)imageSourceConverter.ConvertFrom(tempBitmap);


            imgOutput.Source = image;
        }

        private void btnResize_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (!dlg.ShowDialog().Value)
                return;

            string path = dlg.FileName;

            // Process image

            ImageRecognitionAndProcessingClient client = new ImageRecognitionAndProcessingClient();

            byte[] bytes = client.Resize(File.ReadAllBytes(path), 200, 200);
            MemoryStream input = new MemoryStream(bytes);

            System.Drawing.Image outcome = System.Drawing.Image.FromStream(input);


            var imageSourceConverter = new ImageSourceConverter();
            byte[] tempBitmap = BitmapToByte((System.Drawing.Bitmap)outcome);
            ImageSource image = (ImageSource)imageSourceConverter.ConvertFrom(tempBitmap);


            imgOutput.Source = image;

            // Log success

            CloudmersiveAuditClient client2 = new CloudmersiveAuditClient();

            AuditLogWriteRequest req = new AuditLogWriteRequest();
            req.AuditLogMessage = "Successfully processed image.";
            req.AuditLogReferenceIP = GetLocalIPAddress();
            req.AuditLogMeta = dlg.FileName;

            CloudmersiveValidationApiClient valid = new CloudmersiveValidationApiClient();
            var geo = valid.GeolocateIP(req.AuditLogReferenceIP);
            req.AuditLogReferenceLocation = JsonConvert.SerializeObject(geo);

            client2.WriteLogMessageFull(req);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CloudmersiveNlpApiClient client = new CloudmersiveNlpApiClient();

            txtOutput.Text = JsonConvert.SerializeObject( client.DetectLanguage(txtInput.Text) );
        }
    }
}
