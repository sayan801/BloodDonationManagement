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

namespace Events
{
    /// <summary>
    /// Interaction logic for AddUpcomingEventWindow.xaml
    /// </summary>
    public partial class AddUpcomingEventWindow : Window
    {

        string eventId;
        bool isEdit = false;

        public AddUpcomingEventWindow(BDMSData.EventInfo info)
        {
            InitializeComponent();

            if (info != null)
            {
                isEdit = true;
                eventTitleBtn.Text = info.eventTitle;
                dOEDatePicker.Text = info.eventDoe.ToString();
                venueBtn.Text = info.eventVenue;
                goalofEventBtn.Text = info.eventGoal;

                eventId = info.id;
            }
        }

        private void cancelAddUpcomingEventBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void submitAddUpcomingEventBtn_Click(object sender, RoutedEventArgs e)
        {
            BDMSData.EventInfo eventInf = new BDMSData.EventInfo();
            eventInf.id = GenerateId();
            eventInf.eventTitle = eventTitleBtn.Text;
            eventInf.eventVenue = venueBtn.Text;
            eventInf.eventGoal = goalofEventBtn.Text;
            eventInf.eventDoe = dOEDatePicker.SelectedDate.Value;

            if (isEdit == false)
            {


                eventInf.id = GenerateId();
                BDMSDb.DbInteraction.DoRegisterNewEvent(eventInf);
            }
            else
            {
                eventInf.id = eventId;
                BDMSDb.DbInteraction.EditEvent(eventInf);
            }
            

            this.Close();
        }



        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }
    }
}
