using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BDMS.Windows
{
    /// <summary>
    /// Interaction logic for WebSync.xaml
    /// </summary>
    public partial class WebSync : Window
    {
        public WebSync()
        {
            InitializeComponent();
        }

        //#region donor

        //private void donorWb_Loaded(object sender, RoutedEventArgs e)
        //{
        //    LoadAddDonorGoogleForm();
        //}

        //private void reloadDonorBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    LoadAddDonorGoogleForm();
        //}

        //private void LoadAddDonorGoogleForm()
        //{
        //    donorWb.NavigateToString("<html><body><iframe src=\"https://docs.google.com/spreadsheet/embeddedform?formkey=dEZ0TzRuVFlaX1liNXdXLVYwd0lRY3c6MQ\" width=\"760\" height=\"800\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\">Loading...</iframe></body></html>");
        //}

        //#endregion


        //#region patient

        //private void LoadAddPatientGoogleForm()
        //{
        //    patientWb.NavigateToString("<html><body><iframe src=\"https://docs.google.com/spreadsheet/embeddedform?formkey=dC1pYVNxWXRDWkstZ1ZCRXZYSTFMZWc6MQ\" width=\"760\" height=\"800\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\">Loading...</iframe></body></html>");
        //}       

        //private void patientWb_Loaded(object sender, RoutedEventArgs e)
        //{
        //    LoadAddPatientGoogleForm();
        //}

        //private void reloadPatientBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    LoadAddPatientGoogleForm();
        //}
        //#endregion

        //private void viewDonorWb_Loaded(object sender, RoutedEventArgs e)
        //{
        //    LoadViewDonorGoogleForm();
        //}
        //private void LoadViewDonorGoogleForm()
        //{
        //    donorWb.Navigate("https://docs.google.com/spreadsheet/pub?key=0Aiz8njVDMmtadEZ0TzRuVFlaX1liNXdXLVYwd0lRY3c&single=true&gid=0&output=html");
        //}


        //private void viewPatientWb_Loaded(object sender, RoutedEventArgs e)
        //{
        //    LoadViewPatientsGoogleForm();   
        //}

        //private void LoadViewPatientsGoogleForm()
        //{
        //    donorWb.Navigate("https://docs.google.com/spreadsheet/pub?key=0Aiz8njVDMmtadC1pYVNxWXRDWkstZ1ZCRXZYSTFMZWc&single=true&gid=0&output=html");
        //}

        private void registerDonorBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWb.NavigateToString("<html><body><iframe src=\"https://docs.google.com/spreadsheet/embeddedform?formkey=dEZ0TzRuVFlaX1liNXdXLVYwd0lRY3c6MQ\" width=\"760\" height=\"800\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\">Loading...</iframe></body></html>");
        }

        private void registerPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWb.NavigateToString("<html><body><iframe src=\"https://docs.google.com/spreadsheet/embeddedform?formkey=dC1pYVNxWXRDWkstZ1ZCRXZYSTFMZWc6MQ\" width=\"760\" height=\"900\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\">Loading...</iframe></body></html>");
        }

        private void viewDonorBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWb.Navigate("https://docs.google.com/spreadsheet/pub?key=0Aiz8njVDMmtadEZ0TzRuVFlaX1liNXdXLVYwd0lRY3c&single=true&gid=0&output=html");
        }

        private void viewPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWb.Navigate("https://docs.google.com/spreadsheet/pub?key=0Aiz8njVDMmtadC1pYVNxWXRDWkstZ1ZCRXZYSTFMZWc&single=true&gid=0&output=html");
        }

        private void mainWb_Loaded(object sender, RoutedEventArgs e)
        {
              mainWb.NavigateToString("<html><body><br><br><br><br><br><br><br><br><br><br><br><br><h1  style=\"text-align: center; vertical-align:center; margin: 10px auto\">Welcome to BDMS Web Interface</h1></body></html>");
        }
    }
}
