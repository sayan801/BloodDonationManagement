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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Help
{
    /// <summary>
    /// Interaction logic for HelpWindow.xaml
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void changePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            Help.ChangePasswordWindow ChangePasswordWindowObj = new Help.ChangePasswordWindow();
            ChangePasswordWindowObj.Show();
        }

        private void hospitalDoctorBloodBankBtn_Click(object sender, RoutedEventArgs e)
        {
            Help.HospitalDoctorBloodBankWindow HospitalDoctorBloodBankWindowObj = new Help.HospitalDoctorBloodBankWindow();
            HospitalDoctorBloodBankWindowObj.Show();
        }

        private void okHelpBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
