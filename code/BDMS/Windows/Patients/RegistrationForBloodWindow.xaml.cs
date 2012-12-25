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

namespace Patients
{
    /// <summary>
    /// Interaction logic for RegistrationForBloodWindow.xaml
    /// </summary>
    public partial class RegistrationForBloodWindow : Window
    {
        string patientId;
        bool isEdit = false;

        public RegistrationForBloodWindow(BDMSData.PatientInfo info)
        {
            InitializeComponent();
            if (info != null)
            {
                isEdit = true;
                patientsNameTB.Text = info.name;
                addressdTB.Text = info.address; //info.doj.ToString();
                bloodGroupComboBox.Text = info.bloodGroup;
                ageTB.Text = info.age.ToString();
                expectedDateDatePicker.Text = info.expectedDate.ToString();
                admittedAddressTB.Text = info.admittedAddress;
                contactNoBtn.Text = info.phone;

                patientId = info.id;
            }
       
        }

        private void cancelRegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitRegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            BDMSData.PatientInfo newPatientReg = new BDMSData.PatientInfo();

            newPatientReg.id = GenerateId();
            newPatientReg.name = patientsNameTB.Text;
            newPatientReg.bloodGroup = bloodGroupComboBox.Text;
            newPatientReg.age = Convert.ToInt32(ageTB.Text);
            newPatientReg.address = addressdTB.Text;
            newPatientReg.phone = contactNoBtn.Text;
            newPatientReg.admittedAddress = admittedAddressTB.Text;
            newPatientReg.expectedDate = expectedDateDatePicker.SelectedDate.Value;

            if (isEdit == false)
            {
                newPatientReg.id = GenerateId();
                BDMSDb.DbInteraction.DoRegisterPatient(newPatientReg);
            }
            else
            {
                newPatientReg.id = patientId;
                BDMSDb.DbInteraction.EditPatient(newPatientReg);
            }
            

            this.Close();

        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
    }
}
