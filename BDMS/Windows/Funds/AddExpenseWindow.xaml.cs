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

namespace Funds
{
    /// <summary>
    /// Interaction logic for AddExpenseWindow.xaml
    /// </summary>
    public partial class AddExpenseWindow : Window
    {

        string expenseId;
        bool isEdit = false;

        public AddExpenseWindow(BDMSData.ExpenseInfo info)
        {
            InitializeComponent();

            if (info != null)
            {
                isEdit = true;
                expensePurposeTB.Text = info.purpose;
                dOEDatePicker.Text = info.doe.ToString();
                expensedByTB.Text = info.expensed_by;
                expensedAmountsTB.Text = info.amount.ToString();


                expenseId = info.id;
            }
        }

        private void cancelAddExpenseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitAddExpenseBtn_Click(object sender, RoutedEventArgs e)
        {
            BDMSData.ExpenseInfo newExpense = new BDMSData.ExpenseInfo();

            newExpense.id = GenerateId();
            newExpense.purpose = expensePurposeTB.Text;
            newExpense.doe = dOEDatePicker.SelectedDate.Value;
            newExpense.expensed_by = expensedByTB.Text;
            newExpense.amount = Convert.ToDouble(expensedAmountsTB.Text);

            if (isEdit == false)
            {
                newExpense.id = GenerateId();
                BDMSDb.DbInteraction.DoRegisterNewExpense(newExpense);
            }
            else
            {
                newExpense.id = expenseId;
                BDMSDb.DbInteraction.EditExpense(newExpense);
            }
           

            this.Close();

        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
    }
}
