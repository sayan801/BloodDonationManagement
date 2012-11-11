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

namespace Donors
{
    /// <summary>
    /// Interaction logic for DonorsWindow.xaml
    /// </summary>
    public partial class DonorsWindow : Window
    {

        ObservableCollection<DonorInfo> _donorCollection = new ObservableCollection<DonorInfo>();


        public ObservableCollection<DonorInfo> donorCollection
        {
            get
            {
                return _donorCollection;
            }
        }

        public DonorsWindow()
        {
            InitializeComponent();
        }

        private void addDonorBtn_Click(object sender, RoutedEventArgs e)
        {
            Donors.DonorDetailsWindow AddDonorWindowObj = new Donors.DonorDetailsWindow(null);
            AddDonorWindowObj.Show();
        }

        private void okDonorBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewDonorBtn_Click(object sender, RoutedEventArgs e)
        {
            List<DonorInfo> donors = BDMSDb.DbInteraction.GetAllDonorList();

            _donorCollection.Clear();

            foreach (DonorInfo donor in donors)
            {
                _donorCollection.Add(donor);
            }
        }

        private void deleteDonorBtn_Click(object sender, RoutedEventArgs e)
        {
            DonorInfo donorToDelete = GetSelectedItem();
            if (donorToDelete != null)
            {
                _donorCollection.Remove(donorToDelete);
                BDMSDb.DbInteraction.DeleteDonor(donorToDelete.id);
            }
        }

        private DonorInfo GetSelectedItem()
        {

            DonorInfo donorToDelete = null;

            if (donorView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                DonorInfo i = (DonorInfo)donorView.SelectedItem;

                donorToDelete = _donorCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return donorToDelete;
        }

        private void editDonorBtn_Click(object sender, RoutedEventArgs e)
        {
            DonorInfo donorToEdit = GetSelectedItem();
            if (donorToEdit != null)
            {
                Donors.DonorDetailsWindow AddDonorWindowObj = new Donors.DonorDetailsWindow(donorToEdit);
                AddDonorWindowObj.Show();             
            }
        }

      

        
    }
}
