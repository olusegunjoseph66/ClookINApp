using ClockINVerraki.DbContext;
using ClockINVerraki.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ClockINVerraki.Page
{
    /// <summary>
    /// Interaction logic for AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window
    {
        private readonly ClockinDBContext<Department> _mongoDataProvider;
        public AddDepartment()
        {
            InitializeComponent();

            string connectionString = "mongodb://localhost:27017";
            string databaseName = "DemoDatabase";
            string collectionName = "Departments";

            _mongoDataProvider = new ClockinDBContext<Department>(connectionString, databaseName, collectionName);

            //LoadDepartmentsAsync();
        }

        private async void CreateDepartment_Click(object sender, RoutedEventArgs e)
        {
            var department = new Department
            {
                Id = new Random().Next(100, 2000),
                Name = NameTextBox.Text.ToUpper()
            };

            try
            {
                var checkdepartment = await _mongoDataProvider.GetByIdAsync(department.Id);
                if (checkdepartment == null)
                {
                    await _mongoDataProvider.InsertAsync(department);
                    MessageBox.Show("Department added successfully!");

                }  
                else
                {
                    var deptId = 0;
                    deptId = department.Id + 1;
                    department.Id = deptId;
                    await _mongoDataProvider.InsertAsync(department);
                    MessageBox.Show("Department added successfully!");
                    //MessageBox.Show("Department Already exists!");
                }
                //ClearInputs();
                await LoadDepartmentsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private async System.Threading.Tasks.Task LoadDepartmentsAsync()
        {
            try
            {
                List<Department> items = (List<Department>)await _mongoDataProvider.GetAllAsync();
                ItemsListBox.ItemsSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        private void ClearInputs()
        {
            NameTextBox.Clear();
        }

        private async void DeleteDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsListBox.SelectedItem is Department selectedItem)
            {
                try
                {
                    await _mongoDataProvider.DeleteAsync(selectedItem.Id);
                    MessageBox.Show("Department deleted successfully!");
                    await LoadDepartmentsAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }

        }
    }
}

