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
using BDMSData;
using System.Collections.ObjectModel;


namespace BDMS
{
    /// <summary>
    /// Interaction logic for AssignDonor.xaml
    /// </summary>
    public partial class AssignDonor : Window
    {
        ObservableCollection<DonorInfo> _donorCollection = new ObservableCollection<DonorInfo>();


        public ObservableCollection<DonorInfo> donorCollection
        {
            get
            {
                return _donorCollection;
            }
        }

        public AssignDonor(BDMSData.PatientInfo info)
        {
            InitializeComponent();
            if (info != null)
            {
                patientsIdTB.Text = info.id;
                patientsNameTB.Text = info.name;
                bloodGroup.Text = info.bloodGroup;
                expectedDate.Text =info.expectedDate.ToString();
                admittedAddressTB.Text = info.admittedAddress;
                contactNoBtn.Text = info.phone;



            }
        }

        private void cancelRegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<DonorInfo> donors = BDMSDb.DbInteraction.GetAllDonorList();

            _donorCollection.Clear();

            foreach (DonorInfo donor in donors)
            {
                _donorCollection.Add(donor);
            }
        }

        private void assignedDonorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string donorId = (e.AddedItems[0] as DonorInfo).id;
            DonorInfo donorInfoObj = BDMSDb.DbInteraction.getDonorInfo(donorId);
            donorContactBtn.Text = donorInfoObj.phone;
           
        }

        private void submitRegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            PatientInfo patientData = new BDMSData.PatientInfo();
            patientData.id = patientsIdTB.Text;
            patientData.assignedDonor = assignedDonorComboBox.Text;
            patientData.donorContact = donorContactBtn.Text;
            BDMSDb.DbInteraction.assignDonor(patientData);
            this.Close();
        }

    }
}
