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
using System.Collections.ObjectModel;
using BDMSData;

namespace Patients
{
    /// <summary>
    /// Interaction logic for PatientsWindow.xaml
    /// </summary>
    public partial class PatientsWindow : Window
    {
        ObservableCollection<PatientInfo> _patientCollection = new ObservableCollection<PatientInfo>();


        public ObservableCollection<PatientInfo> patientCollection
        {
            get
            {
                return _patientCollection;
            }
        }

        public PatientsWindow()
        {
            InitializeComponent();
        }

        private void registrationForBloodBtn_Click(object sender, RoutedEventArgs e)
        {
            Patients.RegistrationForBloodWindow RegistrationForBloodWindowObj = new Patients.RegistrationForBloodWindow(null);
            RegistrationForBloodWindowObj.Show();
        }

        private void searchForBloodBtn_Click(object sender, RoutedEventArgs e)
        {
            Patients.SearchForBloodWindow SearchForBloodWindowObj = new Patients.SearchForBloodWindow();
            SearchForBloodWindowObj.Show();
        }

        private void okPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewRegisteredPatientsBtn_Click(object sender, RoutedEventArgs e)
        {
            List<PatientInfo> patients = BDMSDb.DbInteraction.GetAllPatientList();

            _patientCollection.Clear();

            foreach (PatientInfo patient in patients)
            {
                _patientCollection.Add(patient);
            }
        }

        private void deleteRegisteredPatientsBtn_Click(object sender, RoutedEventArgs e)
        {

            PatientInfo patientToDelete = GetSelectedItem();
            if (patientToDelete != null)
            {
                _patientCollection.Remove(patientToDelete);
                BDMSDb.DbInteraction.DeletePatient(patientToDelete.id);
            }
        }

        private PatientInfo GetSelectedItem()
        {

            PatientInfo patientToDelete = null;

            if (patientView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                PatientInfo i = (PatientInfo)patientView.SelectedItem;

                patientToDelete = _patientCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return patientToDelete;
        }

        private void editRegisteredPatientsBtn_Click(object sender, RoutedEventArgs e)
        {
            PatientInfo patientToEdit = GetSelectedItem();
            if (patientToEdit != null)
            {
                Patients.RegistrationForBloodWindow AddPatientWindowObj = new Patients.RegistrationForBloodWindow(patientToEdit);
                AddPatientWindowObj.Show();
            }
        }
        
    }
}
