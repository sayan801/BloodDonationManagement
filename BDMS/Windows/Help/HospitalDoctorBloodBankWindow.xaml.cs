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
using System.Collections.ObjectModel;
using BDMSData;

namespace Help
{
    /// <summary>
    /// Interaction logic for HospitalDoctorBloodBankWindow.xaml
    /// </summary>
    public partial class HospitalDoctorBloodBankWindow : Window
    {


        ObservableCollection<HdbbInfo> _hdbbCollection = new ObservableCollection<HdbbInfo>();


        public ObservableCollection<HdbbInfo> hdbbCollection
        {
            get
            {
                return _hdbbCollection;
            }
        }


        public HospitalDoctorBloodBankWindow()
        {
            InitializeComponent();
        }

        private void addHospitalDoctorBloodBankBtn_Click(object sender, RoutedEventArgs e)
        {
            Help.AddHospitalDoctorBloodBankWindow AddHospitalDoctorBloodBankWindowObj = new Help.AddHospitalDoctorBloodBankWindow(null);
            AddHospitalDoctorBloodBankWindowObj.Show();
        }

        private void okHDBBBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            List<HdbbInfo> hdbbs = BDMSDb.DbInteraction.GetAllHdbbList();

            _hdbbCollection.Clear();

            foreach (HdbbInfo hdbb in hdbbs)
            {
                _hdbbCollection.Add(hdbb);
            }
        }

        private void deleteDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            HdbbInfo hdbbToDelete = GetSelectedItem();
            if (hdbbToDelete != null)
            {
                _hdbbCollection.Remove(hdbbToDelete);
                BDMSDb.DbInteraction.DeleteHdbb(hdbbToDelete.id);
            }
        }

        private HdbbInfo GetSelectedItem()
        {

            HdbbInfo hdbbToDelete = null;

            if (hdbbView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                HdbbInfo i = (HdbbInfo)hdbbView.SelectedItem;

                hdbbToDelete = _hdbbCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return hdbbToDelete;
        }

        private void editDetailsBtn_Click(object sender, RoutedEventArgs e)
        {
            HdbbInfo hdbbToEdit = GetSelectedItem();
            if (hdbbToEdit != null)
            {
                Help.AddHospitalDoctorBloodBankWindow AddHdbbWindowObj = new Help.AddHospitalDoctorBloodBankWindow(hdbbToEdit);
                AddHdbbWindowObj.Show();
            }
        }
    }
}
