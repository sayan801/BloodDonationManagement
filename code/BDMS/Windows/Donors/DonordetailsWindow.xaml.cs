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

namespace Donors
{
    /// <summary>
    /// Interaction logic for AddDonorWindow.xaml
    /// </summary>
    public partial class DonorDetailsWindow : Window
    {
        string donorId;
        bool isEdit = false;

        public DonorDetailsWindow(BDMSData.DonorInfo info)
        {
            InitializeComponent();

            if (info != null)
            {
                isEdit = true;
                donorsNameTb.Text = info.name;
                bloodGroupComboBox.Text = info.bloodGroup;
                dOBDatePicker.Text = info.dob.ToString();
                addressdBtn.Text = info.address;
                contactNoTB.Text = info.phone;
                lastDonationDatePicker.Text = info.lastDonateDate.ToString();

                donorId = info.id;
            }
        }

        private void cancelAddDonorBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void submitAddDonorBtn_Click(object sender, RoutedEventArgs e)
        {
            BDMSData.DonorInfo newDonor = new BDMSData.DonorInfo();
            newDonor.name = donorsNameTb.Text;
            newDonor.lastDonateDate = lastDonationDatePicker.SelectedDate.Value;
            newDonor.dob = dOBDatePicker.SelectedDate.Value;
            newDonor.address = addressdBtn.Text;
            newDonor.bloodGroup = bloodGroupComboBox.Text;
            newDonor.phone = contactNoTB.Text;

            if (isEdit == false)
            {


                newDonor.id = GenerateId();             
                BDMSDb.DbInteraction.DoRegisterNewDonor(newDonor);
            }
            else
            {

                newDonor.id = donorId;
                BDMSDb.DbInteraction.EditDonor(newDonor);
            }

            this.Close();

        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }


    }
}
