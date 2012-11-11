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
using BDMS.Windows;

namespace BDMS
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

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoggedIn == false)
            {
                Login.LoginWindow LoginWindowObj = new Login.LoginWindow();
                LoginWindowObj.OnSucccesfulLogin += new Login.LoginWindow.delegateOnSucccesfulLogin(LoginWindowObj_OnSucccesfulLogin);
                LoginWindowObj.ShowDialog();
            }
            else
            {
                mainDocPanel.IsEnabled = false;
                loginBtn.Content = "Login";
                loginBtn.ToolTip = "Click to Login";
                LoggedIn = false;
            }
        }

        bool LoggedIn = false;

        void LoginWindowObj_OnSucccesfulLogin(string returnMsg)
        {
            mainDocPanel.IsEnabled = true;
            loginBtn.Content = "Logout";
            loginBtn.ToolTip = "Click to Logout";
            LoggedIn = true;
        }

        private void donorsBtn_Click(object sender, RoutedEventArgs e)
        {
            Donors.DonorsWindow DonorsWindowObj = new Donors.DonorsWindow();
            DonorsWindowObj.Show();
        }

        private void patientsBtn_Click(object sender, RoutedEventArgs e)
        {
            Patients.PatientsWindow PatientsWindowObj = new Patients.PatientsWindow();
            PatientsWindowObj.Show();
        }


        private void membersBtn_Click(object sender, RoutedEventArgs e)
        {
            Members.MembersWindow MembersWindowObj = new Members.MembersWindow();
            MembersWindowObj.Show();
        }

 

        private void eventsBtn_Click(object sender, RoutedEventArgs e)
        {
            Events.EventsWindow EventsWindowObj = new Events.EventsWindow();
            EventsWindowObj.Show();
        }

        private void calculatorBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("calc");
        }

        private void helpBtn_Click(object sender, RoutedEventArgs e)
        {
            Help.HelpWindow HelpWindowObj = new Help.HelpWindow();
            HelpWindowObj.Show();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void toDoBtn_Click(object sender, RoutedEventArgs e)
        {
            ToDo.ToDoWindow ToDoWindowObj = new ToDo.ToDoWindow();
            ToDoWindowObj.Show();
        }

        private void wellWisherBtn_Click(object sender, RoutedEventArgs e)
        {
            WellWishers.WellWishersWindow WellWishersWindowObj = new WellWishers.WellWishersWindow();
            WellWishersWindowObj.Show();
        }

        private void fundsBtn_Click(object sender, RoutedEventArgs e)
        {
            Funds.FundsWindow FundsWindowObj = new Funds.FundsWindow();
            FundsWindowObj.Show();
        }

        private void donorAssignmentBtn_Click(object sender, RoutedEventArgs e)
        {
            DonorAssignmentDetails.DonorAssignmentDetails DonorAssignmentDetailsObj= new DonorAssignmentDetails.DonorAssignmentDetails();
            DonorAssignmentDetailsObj.Show();
        }

        private void webSyncBtn_Click(object sender, RoutedEventArgs e)
        {
            WebSync webSyncWindow = new WebSync();
            webSyncWindow.Show();
        }

        private void generateTestimonialBtn_Click(object sender, RoutedEventArgs e)
        {
            BDMS.Testimonial TestimonialObj = new BDMS.Testimonial();
            TestimonialObj.Show();
        }




    }
}
