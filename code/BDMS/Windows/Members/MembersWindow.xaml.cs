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

namespace Members
{
    /// <summary>
    /// Interaction logic for MembersWindow.xaml
    /// </summary>
    public partial class MembersWindow : Window
    {


        ObservableCollection<MemberInfo> _memberCollection = new ObservableCollection<MemberInfo>();


        public ObservableCollection<MemberInfo> memberCollection
        {
            get
            {
                return _memberCollection;
            }
        }

        public MembersWindow()
        {
            InitializeComponent();
        }

        private void addMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            Members.MemberDetailsWindow AddMemberWindowObj = new Members.MemberDetailsWindow(null);
            AddMemberWindowObj.Show();
        }

        private void okMembersBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void viewMembersBtn_Click(object sender, RoutedEventArgs e)
        {
            List<MemberInfo> members = BDMSDb.DbInteraction.GetAllMemberList();

            _memberCollection.Clear();

            foreach (MemberInfo member in members)
            {
                _memberCollection.Add(member);
            }
        }

        private void deleteMemberBtn_Click(object sender, RoutedEventArgs e)
        {

            MemberInfo memberToDelete = GetSelectedItem();
            if (memberToDelete != null)
            {
                _memberCollection.Remove(memberToDelete);
                BDMSDb.DbInteraction.DeleteMember(memberToDelete.id);
            }
        }

        private MemberInfo GetSelectedItem()
        {

            MemberInfo memberToDelete = null;

            if (memberView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                MemberInfo i = (MemberInfo)memberView.SelectedItem;

                memberToDelete = _memberCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return memberToDelete;
        }

        private void editMemberBtn_Click(object sender, RoutedEventArgs e)
        {
            MemberInfo memberToEdit = GetSelectedItem();
            if (memberToEdit != null)
            {
                Members.MemberDetailsWindow AddMemberWindowObj = new Members.MemberDetailsWindow(memberToEdit);
                AddMemberWindowObj.Show();
            }
        }
    }
}
