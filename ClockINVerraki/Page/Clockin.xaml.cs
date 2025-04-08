using ClockINVerraki.DbContext;
using ClockINVerraki.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClockINVerraki.Page
{
    /// <summary>
    /// Interaction logic for Clockin.xaml
    /// </summary>
    public partial class Clockin : Window
    {
        private readonly ClockinDBContext<ClockUser> _mongoDataProvider;
        private readonly ClockinDBContext<UserST> _userDataProvider;
        private readonly ClockinDBContext<Department> _deptDataProvider;
        public Clockin()
        {
            InitializeComponent();
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "DemoDatabase";

            _mongoDataProvider = new ClockinDBContext<ClockUser>(connectionString, databaseName, "ClockUsers");
            _userDataProvider = new ClockinDBContext<UserST>(connectionString, databaseName, "UserSTs");
            _deptDataProvider = new ClockinDBContext<Department>(connectionString, databaseName, "Departments");
        }

        private async void UserIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = UserIdTextBox.Text;

            if (!string.IsNullOrWhiteSpace(text))
            {
                await SaveRecordToMongoDBAsync(text);
                StatusTextBlock.Text = $"ID: {text} Just Clocked Now";
            }
        }

        private async Task SaveRecordToMongoDBAsync(string text)
        {
            try
            {
                var user = await _userDataProvider.GetByIdAsync(int.Parse(text));                
            
                if (user == null)
                {
                    var clockUser = new ClockUser
                    {
                        Id = new Random().Next(100, 2000),
                        UserId = int.Parse(text),
                        IsStaff = false,
                        GetTime = DateTime.UtcNow,

                    };
                    await _mongoDataProvider.InsertAsync(clockUser);
                }
                else 
                {
                    var dept = await _deptDataProvider.GetByIdAsync(user.DepartmentId);
                    var clockUser = new ClockUser
                    {
                        Id = new Random().Next(100, 2000),
                        UserId = int.Parse(text),
                        IsStaff = true,
                        DepartmentId = dept.Id,
                        GetTime = DateTime.UtcNow,

                    };
                    await _mongoDataProvider.InsertAsync(clockUser);
                }
                

                

            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Error: {ex.Message}";
            }
        }

        private void UserIdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Regex to allow only numbers (0-9)
            Regex regex = new Regex("^[0-9]+$");

            if (!regex.IsMatch(e.Text))
            {
                // If input is not a number, reject it
                e.Handled = true;
                ValidationMessage.Text = "Only numeric input is allowed.";
            }
            else
            {
                // Clear validation message if input is valid
                ValidationMessage.Text = string.Empty;
            }
        }
    }
}
