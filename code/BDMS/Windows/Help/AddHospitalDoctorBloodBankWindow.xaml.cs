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

namespace Help
{
    /// <summary>
    /// Interaction logic for AddHospitalDoctorBloodBankWindow.xaml
    /// </summary>
    public partial class AddHospitalDoctorBloodBankWindow : Window
    {

        string hdbbId;
        bool isEdit = false;
        public AddHospitalDoctorBloodBankWindow(BDMSData.HdbbInfo info)
        {
            InitializeComponent();

            if (info != null)
            {
                isEdit = true;
                typeComboBox.Text = info.type;
                nameTB.Text = info.name;
                addressTB.Text = info.address;
                contactNoTB.Text = info.phone;
                            
                hdbbId = info.id;
            }
        }

        private void cancelAddHospitalDoctorBloodBankBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitAddHospitalDoctorBloodBankBtn_Click(object sender, RoutedEventArgs e)
        {
            BDMSData.HdbbInfo newHdbb = new BDMSData.HdbbInfo();

            newHdbb.id = GenerateId();
            newHdbb.type = typeComboBox.Text;
            newHdbb.name = nameTB.Text;
            newHdbb.address = addressTB.Text;
            newHdbb.phone = contactNoTB.Text;

            if (isEdit == false)
            {
                newHdbb.id = GenerateId();
                BDMSDb.DbInteraction.DoRegisterNewHdbb(newHdbb);
            }
            else
            {
                newHdbb.id = hdbbId;
                BDMSDb.DbInteraction.EditHdbb(newHdbb);
            }
            

            this.Close();

        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }

        private void contactNoTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
