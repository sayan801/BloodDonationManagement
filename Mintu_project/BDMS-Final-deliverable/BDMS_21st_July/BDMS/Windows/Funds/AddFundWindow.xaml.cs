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

namespace Funds
{
    /// <summary>
    /// Interaction logic for AddFundWindow.xaml
    /// </summary>
    public partial class AddFundWindow : Window
    {
        ObservableCollection<WellWisherInfo> _WellWisherCollection = new ObservableCollection<WellWisherInfo>();


        public ObservableCollection<WellWisherInfo> WellWisherCollection
        {
            get
            {
                return _WellWisherCollection;
            }
        }

        ObservableCollection<MemberInfo> _memberCollection = new ObservableCollection<MemberInfo>();


        public ObservableCollection<MemberInfo> memberCollection
        {
            get
            {
                return _memberCollection;
            }
        }

        string fundId;
        bool isEdit = false;

        public AddFundWindow(BDMSData.FundInfo info)
        {
            InitializeComponent();

            if (info != null)
            {
                isEdit = true;
                well_wisher_name.Text = info.wellwisher_name;
                contactNoTB.Text = info.contact;
                dODDatePicker.Text = info.dod.ToString();
                receivedByComboBox.Text = info.received_by;
                amountsTB.Text = info.amount.ToString();

                fundId = info.id;
            }
        }

        private void cancelAddExpenseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitAddFundBtn_Click(object sender, RoutedEventArgs e)
        {
            BDMSData.FundInfo newFund = new BDMSData.FundInfo();

            newFund.id = GenerateId();
            newFund.wellwisher_name = well_wisher_name.Text;
            newFund.contact = contactNoTB.Text;
            newFund.dod = dODDatePicker.SelectedDate.Value;
            newFund.received_by = receivedByComboBox.Text;
            newFund.amount = Convert.ToDouble(amountsTB.Text);


            if (isEdit == false)
            {
                newFund.id = GenerateId();
                BDMSDb.DbInteraction.DoRegisterNewFund(newFund);
            }
            else
            {
                newFund.id = fundId;
                BDMSDb.DbInteraction.EditFund(newFund);
            }
            

            this.Close();

        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<WellWisherInfo> wellWishers = BDMSDb.DbInteraction.GetAllWellWisherList();

            _WellWisherCollection.Clear();

            foreach (WellWisherInfo wellWisr in wellWishers)
            {
                _WellWisherCollection.Add(wellWisr);
            }

            List<MemberInfo> members = BDMSDb.DbInteraction.GetAllMemberList();

            _memberCollection.Clear();

            foreach (MemberInfo member in members)
            {
                _memberCollection.Add(member);
            }
        }
    }
}
