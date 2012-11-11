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

namespace Login
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public delegate void delegateOnSucccesfulLogin(string returnMsg);
        public event delegateOnSucccesfulLogin OnSucccesfulLogin;

        public LoginWindow()
        {
            InitializeComponent();
        }


        private void createAccountBtn_Click(object sender, RoutedEventArgs e)
        {
            Login.CreateAccountWindow CreateAccountWindowObj = new Login.CreateAccountWindow();
            CreateAccountWindowObj.ShowDialog();
        }

        private void cancleloginBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void loginSubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((userIdBtn.Text.Equals("ignou")) && (loginPasswordBox.Password.Equals("project")))
            {
                if (OnSucccesfulLogin != null)
                    OnSucccesfulLogin(userIdBtn.Text);
            }
            else
                MessageBox.Show("Wrong username or Password.");

            this.Close();
        }
    }
}
