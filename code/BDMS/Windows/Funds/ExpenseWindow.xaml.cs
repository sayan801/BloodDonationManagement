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

namespace Funds
{
    /// <summary>
    /// Interaction logic for ExpenseWindow.xaml
    /// </summary>
    public partial class ExpenseWindow : Window
    {
        ObservableCollection<ExpenseInfo> _expenseCollection = new ObservableCollection<ExpenseInfo>();


        public ObservableCollection<ExpenseInfo> expenseCollection
        {
            get
            {
                return _expenseCollection;
            }
        }

        public ExpenseWindow()
        {
            InitializeComponent();
        }

        private void addExpenseBtn_Click(object sender, RoutedEventArgs e)
        {
            Funds.AddExpenseWindow AddExpenseWindowObj = new Funds.AddExpenseWindow(null);
            AddExpenseWindowObj.Show();
        }

        private void okExpenseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewExpenseBtn_Click(object sender, RoutedEventArgs e)
        {
            List<ExpenseInfo> expenses = BDMSDb.DbInteraction.GetAllExpenseList();

            _expenseCollection.Clear();

            foreach (ExpenseInfo expense in expenses)
            {
                _expenseCollection.Add(expense);
            }
        }

        private void deleteExpenseBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpenseInfo expenseToDelete = GetSelectedItem();
            if (expenseToDelete != null)
            {
                _expenseCollection.Remove(expenseToDelete);
                BDMSDb.DbInteraction.DeleteExpense(expenseToDelete.id);
            }
        }

        private ExpenseInfo GetSelectedItem()
        {

            ExpenseInfo expenseToDelete = null;

            if (expenseView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                ExpenseInfo i = (ExpenseInfo)expenseView.SelectedItem;

                expenseToDelete = _expenseCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return expenseToDelete;
        }

        private void editExpenseBtn_Click(object sender, RoutedEventArgs e)
        {
            ExpenseInfo expenseToEdit = GetSelectedItem();
            if (expenseToEdit != null)
             {
                 Funds.AddExpenseWindow AddExpenseWindowObj = new Funds.AddExpenseWindow(expenseToEdit);
                 AddExpenseWindowObj.Show();
             }
        }
    }
}
