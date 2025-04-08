using ClockINVerraki.DbContext;
using ClockINVerraki.Models;
using ClockINVerraki.ViewModels;
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
    /// Interaction logic for Stafflist.xaml
    /// </summary>
    public partial class Stafflist : Window
    {
        public List<UserST> Users { get; set; }
        private readonly ClockinDBContext<UserST> _mongoDataProvider;
        private readonly ClockinDBContext<Department> _departmongoDataProvider;

        public Stafflist()
        {
            InitializeComponent();
           

            string connectionString = "mongodb://localhost:27017";
            string databaseName = "DemoDatabase";
            //string collectionName = "Departments";

            //_mongoDataProvider = new ClockinDBContext<Department>(connectionString, databaseName, collectionName);
            _mongoDataProvider = new ClockinDBContext<UserST>(connectionString, databaseName, "UserSTs");
            _departmongoDataProvider = new ClockinDBContext<Department>(connectionString, databaseName, "Departments");

            LoadUsersAsync();

            DataContext = this;
        }


        private async System.Threading.Tasks.Task LoadUsersAsync()
        {
            try
            {
                List<UserDto> userDtos = new List<UserDto>();
                // ObservableCollection<UserST> items = (ObservableCollection<UserST>)await _mongoDataProvider.GetAllAsync();
                List<UserST> items = (List<UserST>)await _mongoDataProvider.GetAllAsync();
                foreach (var useritem in items)
                {
                    var dept = await _departmongoDataProvider.GetByIdAsync(useritem.DepartmentId);
                    var user = new UserDto { Id = useritem.Id,   CreatedAt = useritem.CreatedAt,
                                        LastName = useritem.LastName,  ImagePath = useritem.ImagePath,
                                        FirstName = useritem.FirstName, DepartmentName = dept.Name };
                     
                    userDtos.Add(user);
                }

                Users = (List<UserST>)await _mongoDataProvider.GetAllAsync();


                //UsersListView.ItemsSource = Users;

                UsersListView.ItemsSource = userDtos.OrderByDescending(i => i.CreatedAt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        private async void ViewMore_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.Tag is UserDto user)
            {
                // Open the DetailsWindow with the selected user's details
                var detailsWindow = new ViewDetails(user);
                detailsWindow.Show();
            }

        }
    }
}
