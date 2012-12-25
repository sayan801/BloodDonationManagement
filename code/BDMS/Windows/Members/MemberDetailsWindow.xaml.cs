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

namespace Members
{
    /// <summary>
    /// Interaction logic for AddMemberWindow.xaml
    /// </summary>
    public partial class MemberDetailsWindow : Window
    {


        string memberId;
        bool isEdit = false;

        public MemberDetailsWindow(BDMSData.MemberInfo info)
        {
            InitializeComponent();

            if (info != null)
            {
                isEdit = true;
                membersNameTB.Text = info.name;
                dOJDatePicker.Text = info.doj.ToString();
                addressTB.Text = info.address;
                contactNoTB.Text = info.phone;

                memberId = info.id;
            }
        }

        private void cancelAddMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitAddMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            BDMSData.MemberInfo newMember = new BDMSData.MemberInfo();

            newMember.id = GenerateId();
            newMember.name = membersNameTB.Text;
            newMember.doj = dOJDatePicker.SelectedDate.Value;
            newMember.address = addressTB.Text;
            newMember.phone = contactNoTB.Text;


            if (isEdit == false)
            {
                newMember.id = GenerateId();
                BDMSDb.DbInteraction.DoRegisterNewMember(newMember);
            }
            else
            {
                newMember.id = memberId;
                BDMSDb.DbInteraction.EditMember(newMember);
            }
                

            this.Close();

        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
        
    }
}
