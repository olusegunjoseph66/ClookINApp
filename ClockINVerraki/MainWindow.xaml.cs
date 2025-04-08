using ClockINVerraki.DbContext;
using ClockINVerraki.Models;
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

namespace ClockINVerraki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();

            
        }

        

        private void adddepartment_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = new Page.AddDepartment();
            myWindow.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void addstaff_Click(object sender, RoutedEventArgs e)
        {

            var myProfile = new Page.CreateUser();
            myProfile.Show();
        }

        private void addclockin_Click(object sender, RoutedEventArgs e)
        {
                
            var myclockin = new Page.Clockin();
            myclockin.Show();
        }

        //private void viewdetails_Click(object sender, RoutedEventArgs e)
        //{

        //    //var mydetails = new Page.ViewDetails( );
        //    //mydetails.Show();
        //}

       
        private void stafflists_Click(object sender, RoutedEventArgs e)
        {
            var stafflists = new Page.Stafflist();
            stafflists.Show();

        }

        private void clockINLists_Click(object sender, RoutedEventArgs e)
        {
            var clockinlists = new Page.ClockINlist();
            clockinlists.Show();
        }
    }
}