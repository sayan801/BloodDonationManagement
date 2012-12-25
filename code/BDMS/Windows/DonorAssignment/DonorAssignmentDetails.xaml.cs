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
using BDMSData;
using System.Collections.ObjectModel;

namespace DonorAssignmentDetails
{
    /// <summary>
    /// Interaction logic for DonorAssignmentDetails.xaml
    /// </summary>
    public partial class DonorAssignmentDetails : Window
    {
        ObservableCollection<PatientInfo> _patientCollection = new ObservableCollection<PatientInfo>();


        public ObservableCollection<PatientInfo> patientCollection
        {
            get
            {
                return _patientCollection;
            }
        }
        public DonorAssignmentDetails()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewDetailssBtn_Click(object sender, RoutedEventArgs e)
        {
            List<PatientInfo> patients = BDMSDb.DbInteraction.GetAllPatientListWithAssignedDonor();

            _patientCollection.Clear();

            foreach (PatientInfo patient in patients)
            {
                _patientCollection.Add(patient);
            }
        }

        private void assignDonorBtn_Click(object sender, RoutedEventArgs e)
        {
            PatientInfo patientToEdit = GetSelectedItem();
            if (patientToEdit != null)
            {
                BDMS.AssignDonor assignDonorWindowObject = new BDMS.AssignDonor(patientToEdit);
                //Patients.RegistrationForBloodWindow AddPatientWindowObj = new Patients.RegistrationForBloodWindow(patientToEdit);
                assignDonorWindowObject.Show();
            }
        }

         private PatientInfo GetSelectedItem()
        {

            PatientInfo patientToDelete = null;

            if (assignedDonorView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                PatientInfo i = (PatientInfo)assignedDonorView.SelectedItem;

                patientToDelete = _patientCollection.Where(item => item.id.Equals(i.id)).First();
            }
            return patientToDelete;
        }

        //private void viewDetailssBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    List<PatientInfo> assign = BDMSDb.DbInteraction.GetAllEstimateList();

        //    _estimateCollection.Clear();

        //    foreach (estimateInfo esm in estimates)
        //    {
        //        string cusId = ESCMSStorage.DbInteraction.GetNewConnectionCustomerId(esm.appsNo);
        //        CustomerInfo cusInfo = ESCMSStorage.DbInteraction.GetCustomerInfo(cusId);

        //        esm.name = cusInfo.name;
        //        esm.address = cusInfo.address;
        //        esm.contact = cusInfo.contact;

        //        _estimateCollection.Add(esm);
        //    }
        //}

    }
}
