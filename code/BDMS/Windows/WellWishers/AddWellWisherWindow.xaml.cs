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

namespace WellWishers
{
    /// <summary>
    /// Interaction logic for AddWellWisherWindow.xaml
    /// </summary>
    public partial class AddWellWisherWindow : Window
    {

        string wellWisherId;
        bool isEdit = false;

        public AddWellWisherWindow(BDMSData.WellWisherInfo info)
        {
            InitializeComponent();

            if (info != null)
            {
                isEdit = true;
                wellWishersNameTB.Text = info.name;
                dOJDatePicker.Text = info.doj.ToString();
                addressdTB.Text = info.address;
                contactNoTB.Text = info.phone;
                remarkTB.Text = info.phone;

                wellWisherId = info.id;
            }
        }

        private void cancelAddWellWisherBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitAddWellWisherBtn_Click(object sender, RoutedEventArgs e)
        {
            BDMSData.WellWisherInfo newWellWisher = new BDMSData.WellWisherInfo();

            newWellWisher.id = GenerateId();
            newWellWisher.name = wellWishersNameTB.Text;
            newWellWisher.doj = dOJDatePicker.SelectedDate.Value;
            newWellWisher.address = addressdTB.Text;
            newWellWisher.phone = contactNoTB.Text;
            newWellWisher.remarks = remarkTB.Text;

            if (isEdit == false)
            {
                newWellWisher.id = GenerateId();
                BDMSDb.DbInteraction.DoRegisterWellWisher(newWellWisher);
            }
            else
            {
                newWellWisher.id = wellWisherId;
                BDMSDb.DbInteraction.EditWellWisher(newWellWisher);
            }
                


            this.Close();
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
    }
}
