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

namespace ToDo
{
    /// <summary>
    /// Interaction logic for ToDoWindow.xaml
    /// </summary>
    public partial class ToDoWindow : Window
    {
        ObservableCollection<TodoInfo> _todoCollection = new ObservableCollection<TodoInfo>();


        public ObservableCollection<TodoInfo> todoCollection
        {
            get
            {
                return _todoCollection;
            }
        }

        public ToDoWindow()
        {
            InitializeComponent();
        }

        private void okToDoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addToDoBtn_Click(object sender, RoutedEventArgs e)
        {
            BDMSData.TodoInfo newTodo = new BDMSData.TodoInfo();

            newTodo.id = GenerateId();
            newTodo.date = DateTime.Now;
            newTodo.details = detailsTB.Text;

            BDMSDb.DbInteraction.DoRegisterNewTodo(newTodo);

            this.Close();

            ToDo.ToDoWindow ToDoWindowObj = new ToDo.ToDoWindow();
            ToDoWindowObj.Show();
        }

        private string GenerateId()
        {
            return DateTime.Now.ToOADate().ToString();
        }

        private void todoListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void viewToDoBtn_Click(object sender, RoutedEventArgs e)
        {
            List<TodoInfo> todoList = BDMSDb.DbInteraction.GetAllTodoList();

            _todoCollection.Clear();

            foreach (TodoInfo todo in todoList)
            {
                _todoCollection.Add(todo);
            }
        }

        private void deleteToDoBtn_Click(object sender, RoutedEventArgs e)
        {
            TodoInfo todoToDelete = GetSelectedItem();
            if (todoToDelete != null)
            {
                _todoCollection.Remove(todoToDelete);
                BDMSDb.DbInteraction.DeleteTodo(todoToDelete.id);
            }
        }

        private TodoInfo GetSelectedItem()
        {

            TodoInfo todoToDelete = null;

            if (todoListView.SelectedIndex == -1)
                MessageBox.Show("Please Select an Item");
            else
            {
                TodoInfo i = (TodoInfo)todoListView.SelectedItem;

                todoToDelete = _todoCollection.Where(item => item.id.Equals(i.id)).First();
            }

            return todoToDelete;
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            TodoInfo ToDoInfoObj = new TodoInfo();
            ToDoInfoObj.details = searchTxtBlck.Text;

            List<TodoInfo> todoList = BDMSDb.DbInteraction.SearchAllTodoList(ToDoInfoObj);

            _todoCollection.Clear();

            foreach (TodoInfo todo in todoList)
            {
                _todoCollection.Add(todo);
            }
        }

        //private void editToDoBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    TodoInfo todoToEdit = GetSelectedItem();
        //    if (todoToEdit != null)
        //    {
        //        Members.MemberDetailsWindow AddMemberWindowObj = new Members.MemberDetailsWindow(memberToEdit);
        //        AddMemberWindowObj.Show();
        //    }
        //}
       
    }
}
