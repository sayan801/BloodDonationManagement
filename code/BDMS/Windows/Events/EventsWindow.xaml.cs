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

namespace Events
{
    /// <summary>
    /// Interaction logic for EventsWindow.xaml
    /// </summary>
    public partial class EventsWindow : Window
    {

        ObservableCollection<EventInfo> _eventCollection = new ObservableCollection<EventInfo>();


        public ObservableCollection<EventInfo> eventCollection
        {
            get
            {
                return _eventCollection;
            }
        }

        public EventsWindow()
        {
            InitializeComponent();
        }

        private void previousEventsBtn_Click(object sender, RoutedEventArgs e)
        {
            Events.PreviousEventsWindow PreviousEventsWindowObj = new Events.PreviousEventsWindow();
            PreviousEventsWindowObj.Show();
        }

        private void addUpcomingEventBtn_Click(object sender, RoutedEventArgs e)
        {
            Events.AddUpcomingEventWindow AddUpcomingEventWindowObj = new Events.AddUpcomingEventWindow(null);
            AddUpcomingEventWindowObj.Show();
        }

        private void okEventsBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void viewUpcomingEventBtn_Click(object sender, RoutedEventArgs e)
        {
            List<EventInfo> events = BDMSDb.DbInteraction.GetAllEventList();

            _eventCollection.Clear();

            foreach (EventInfo evnt in events)
            {
                _eventCollection.Add(evnt);
            }
        }

        private void deleteEventBtn_Click(object sender, RoutedEventArgs e)
        {
            EventInfo eventToDelete = GetSelectedItem();
            if (eventToDelete != null)
            {
                _eventCollection.Remove(eventToDelete);
                BDMSDb.DbInteraction.DeleteEvent(eventToDelete.id);
            }
        }

        private EventInfo GetSelectedItem()
        {

            EventInfo eventToDelete = null;

            if (eventView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                EventInfo i = (EventInfo)eventView.SelectedItem;

                eventToDelete = _eventCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return eventToDelete;
        }

        private void editEventBtn_Click(object sender, RoutedEventArgs e)
        {
            EventInfo eventToEdit = GetSelectedItem();
            if (eventToEdit != null)
            {
                Events.AddUpcomingEventWindow AddEventWindowObj = new Events.AddUpcomingEventWindow(eventToEdit);
                AddEventWindowObj.Show();
            }
        }
    }
}
