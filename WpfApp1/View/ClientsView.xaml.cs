using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Model;

namespace WpfApp1.View
{
    /// <summary>
    /// Interaction logic for ClientsView.xaml
    /// </summary>
    public partial class ClientsView : UserControl
    {

        public ClientsView() 
        {
        }
        /*
        private void RefreshUsers()
        {
            users.Clear();
            
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db;Version=3;"))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT * FROM Users", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2)
                            };

                            users.Add(user);
                        }
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshUsers();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db;Version=3;"))
            {
                connection.Open();
                string name = nameTextBox.Text;
                string email = emailTextBox.Text;

                using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Users (Name, Email) VALUES (@Name, @Email)", connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();
                }
            }

            RefreshUsers();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (userListView.SelectedItem is User selectedUser)
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db;Version=3;"))
                {
                    connection.Open();
                    string name = nameTextBox.Text;
                    string email = emailTextBox.Text;

                    using (SQLiteCommand command = new SQLiteCommand("UPDATE Users SET Name = @Name, Email = @Email WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Id", selectedUser.Id);
                        command.ExecuteNonQuery();
                    }
                }

                RefreshUsers();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (userListView.SelectedItem is User selectedUser)
            {
                using (SQLiteConnection connection = new SQLiteConnection("Data Source=database.db;Version=3;"))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Users WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedUser.Id);
                        command.ExecuteNonQuery();
                    }
                }

                RefreshUsers();
            }
        }

        public ObservableCollection<User> Users
        {
            get { return users; }
        }
        */
    }
}
