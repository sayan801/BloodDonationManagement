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

namespace Funds
{
    /// <summary>
    /// Interaction logic for FundsWindow.xaml
    /// </summary>
    public partial class FundsWindow : Window
    {

        ObservableCollection<FundInfo> _fundCollection = new ObservableCollection<FundInfo>();


        public ObservableCollection<FundInfo> fundCollection
        {
            get
            {
                return _fundCollection;
            }
        }


        public FundsWindow()
        {
            InitializeComponent();
        }

        private void okReportsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addFundBtn_Click(object sender, RoutedEventArgs e)
        {
            Funds.AddFundWindow AddFundWindowObj = new Funds.AddFundWindow(null);
            AddFundWindowObj.Show();
        }

        private void expenseBtn_Click(object sender, RoutedEventArgs e)
        {
           Funds.ExpenseWindow ExpenseWindowObj = new Funds.ExpenseWindow();
           ExpenseWindowObj.Show();
        }

        private void viewFundBtn_Click(object sender, RoutedEventArgs e)
        {
            List<FundInfo> funds = BDMSDb.DbInteraction.GetAllFundList();

            _fundCollection.Clear();

            foreach (FundInfo fund in funds)
            {
                _fundCollection.Add(fund);
            }
        }

        private void deleteFundBtn_Click(object sender, RoutedEventArgs e)
        {
            FundInfo fundToDelete = GetSelectedItem();
            if (fundToDelete != null)
            {
                _fundCollection.Remove(fundToDelete);
                BDMSDb.DbInteraction.DeleteFund(fundToDelete.id);
            }
        }

        private FundInfo GetSelectedItem()
        {

            FundInfo fundToDelete = null;

            if (fundView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                FundInfo i = (FundInfo)fundView.SelectedItem;

                fundToDelete = _fundCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return fundToDelete;
        }

        private void editFundBtn_Click(object sender, RoutedEventArgs e)
        {
            FundInfo fundToEdit = GetSelectedItem();
            if (fundToEdit != null)
            {
                Funds.AddFundWindow AddFundWindowObj = new Funds.AddFundWindow(fundToEdit);
                AddFundWindowObj.Show();
            }
        }
    }
}
