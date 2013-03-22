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

namespace WellWishers
{
    /// <summary>
    /// Interaction logic for WellWishersWindow.xaml
    /// </summary>
    public partial class WellWishersWindow : Window
    {
        ObservableCollection<WellWisherInfo> _WellWisherCollection = new ObservableCollection<WellWisherInfo>();


        public ObservableCollection<WellWisherInfo> WellWisherCollection
        {
            get
            {
                return _WellWisherCollection;
            }
        }
        public WellWishersWindow()
        {
            InitializeComponent();
        }

        private void okWellWishersBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addWellWisherBtn_Click(object sender, RoutedEventArgs e)
        {
            WellWishers.AddWellWisherWindow AddWellWisherWindowObj = new WellWishers.AddWellWisherWindow(null);
            AddWellWisherWindowObj.Show();
        }

        private void viewWellWishersBtn_Click(object sender, RoutedEventArgs e)
        {
            List<WellWisherInfo> wellWishers = BDMSDb.DbInteraction.GetAllWellWisherList();

            _WellWisherCollection.Clear();

            foreach (WellWisherInfo wellWisr in wellWishers)
            {
                _WellWisherCollection.Add(wellWisr);
            }
        }

        private void deleteWellWishersBtn_Click(object sender, RoutedEventArgs e)
        {
            WellWisherInfo wellWisherToDelete = GetSelectedItem();
            if (wellWisherToDelete != null)
            {
                _WellWisherCollection.Remove(wellWisherToDelete);
                BDMSDb.DbInteraction.DeleteWellWisher(wellWisherToDelete.id);
            }
        }

        private WellWisherInfo GetSelectedItem()
        {

            WellWisherInfo wellWisherToDelete = null;

            if (WellWisherView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                WellWisherInfo i = (WellWisherInfo)WellWisherView.SelectedItem;

                wellWisherToDelete = _WellWisherCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return wellWisherToDelete;
        
        }

        private void editWellWishersBtn_Click(object sender, RoutedEventArgs e)
        {
            WellWisherInfo memberToEdit = GetSelectedItem();
            if (memberToEdit != null)
            {
                WellWishers.AddWellWisherWindow AddWellWisherWindowObj = new WellWishers.AddWellWisherWindow(memberToEdit);
                AddWellWisherWindowObj.Show();
            }
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            WellWisherInfo wellWisherInfoObj = new WellWisherInfo();
            wellWisherInfoObj.name = searchTxtBlck.Text;

            List<WellWisherInfo> wellWishers = BDMSDb.DbInteraction.SearchAllWellWisherList(wellWisherInfoObj);

            _WellWisherCollection.Clear();

            foreach (WellWisherInfo wellWisr in wellWishers)
            {
                _WellWisherCollection.Add(wellWisr);
            }

        }

 
    }
}
