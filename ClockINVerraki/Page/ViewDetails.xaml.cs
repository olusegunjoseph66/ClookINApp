using ClockINVerraki.DbContext;
using ClockINVerraki.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Printing;
using System.Windows.Documents;
using ClockINVerraki.ViewModels;

namespace ClockINVerraki.Page
{
    /// <summary>
    /// Interaction logic for ViewDetails.xaml
    /// </summary>
    public partial class ViewDetails : Window
    {
        private readonly ClockinDBContext<UserST> _mongoDataProvider;
        public ICommand PrintCommand { get; }
        //public ViewDetails()
        //{
        //}
        public ViewDetails(UserDto user)
        {
            InitializeComponent();
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "DemoDatabase";

            _mongoDataProvider = new ClockinDBContext<UserST>(connectionString, databaseName, "UserSTs");
            // Bind the PrintCommand
            PrintCommand = new RelayCommand(ExecutePrintCommand);
            DataContext = this;
            LoadDetails(user);

        }


        private async void LoadUserImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get User ID from TextBox
                if (string.IsNullOrWhiteSpace(IDTextBox.Text))
                {
                    MessageBox.Show("Please enter a valid User ID.");
                    return;
                }

                // Parse User ID
                if (!int.TryParse(IDTextBox.Text, out int userId))
                {
                    MessageBox.Show("Invalid User ID format.");
                    return;
                }

                // Fetch User from MongoDB
                //var user = await _mongoDataProvider.GetByIdAsync(user.userId);
                var user = await _mongoDataProvider.GetByIdAsync(userId);
                if (user == null)
                {
                    MessageBox.Show("User not found.");
                    return;
                }

                // Display User Image
                if (!string.IsNullOrEmpty(user.ImagePath) && File.Exists(user.ImagePath))
                {
                    UserPictureImage.Source = new BitmapImage(new Uri(user.ImagePath));
                    FirstNameTextBox.Text = user.FirstName;
                    LastNameTextBox.Text = user.LastName;
                    IDTextBox.Text = user.Id.ToString();
                }
                else
                {
                    MessageBox.Show("User image not found in the folder.");
                }

                // Display Logo (Static Path)
                string logoPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WebcamImages", "logo.png");
                if (File.Exists(logoPath))
                {
                    LogoImage.Source = new BitmapImage(new Uri(logoPath));
                }
                else
                {
                    MessageBox.Show("Logo image not found in the folder.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void LoadDetails(UserDto user)
        {
            // Populate the fields with user details
            UserPictureImage.Source = new BitmapImage(new Uri(user.ImagePath));
            FirstNameTextBox.Text = user.FirstName;
            LastNameTextBox.Text = user.LastName;
            IDTextBox.Text = user.Id.ToString();

            string logoPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WebcamImages", "logo.png");
            if (File.Exists(logoPath))
            {
                LogoImage.Source = new BitmapImage(new Uri(logoPath));
            }
            else
            {
                MessageBox.Show("Logo image not found in the folder.");
            }
        }



        private void ExecutePrintCommand()
        {
            PrintDialog printDialog = new PrintDialog();

            //// Show the print dialog
            if (printDialog.ShowDialog() == true)
            {
                // Measure and arrange the grid for printing
                MainGrid.Measure(new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight));
                MainGrid.Arrange(new Rect(new Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight)));

                // Print the grid
                printDialog.PrintVisual(MainGrid, "StaffDetails");
            }

            //string content = IDTextBox.Text;

            //if (string.IsNullOrWhiteSpace(content))
            //{
            //    MessageBox.Show("There's nothing to print!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    return;
            //}

            //// Create a FlowDocument for printing
            //FlowDocument flowDocument = new FlowDocument(new Paragraph(new Run(content)))
            //{
            //    FontSize = 12,
            //    FontFamily = new System.Windows.Media.FontFamily("Arial")
            //};

            //// Show PrintDialog
            ////PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == true)
            //{
            //    // Print the document
            //    IDocumentPaginatorSource paginator = flowDocument;
            //    printDialog.PrintDocument(paginator.DocumentPaginator, "Printing Document");
            //}
        }
    }

    // RelayCommand implementation
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}


