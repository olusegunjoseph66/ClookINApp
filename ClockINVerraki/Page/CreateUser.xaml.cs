using AForge.Video;
using AForge.Video.DirectShow;
using ClockINVerraki.DbContext;
using ClockINVerraki.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
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
using Path = System.IO.Path;

namespace ClockINVerraki.Page
{
    /// <summary>
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        private readonly ClockinDBContext<UserST> _mongoDataProvider;
        private readonly ClockinDBContext<Department> _departmongoDataProvider;
        public int SelectedItemId { get; set; }
        private FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoSource;
        private Bitmap _currentFrame;
        public CreateUser()
        {
            InitializeComponent();
            string connectionString = "mongodb://localhost:27017";
            string databaseName = "DemoDatabase";
            //string collectionName = "Departments";

            //_mongoDataProvider = new ClockinDBContext<Department>(connectionString, databaseName, collectionName);
            _mongoDataProvider = new ClockinDBContext<UserST>(connectionString, databaseName, "UserSTs");
            _departmongoDataProvider = new ClockinDBContext<Department>(connectionString, databaseName, "Departments");

           
            InitializeWebcam();
            DataContext = this;

            LoadDepartmentsAsync();
        }

        private void InitializeWebcam()
        {
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (_videoDevices.Count > 0)
            {
                _videoSource = new VideoCaptureDevice(_videoDevices[0].MonikerString);
                _videoSource.NewFrame += VideoSource_NewFrame;
                _videoSource.Start();
            }
            else
            {
                MessageBox.Show("No webcam detected.");
            }
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            _currentFrame = (Bitmap)eventArgs.Frame.Clone();
            Application.Current.Dispatcher.Invoke(() =>
            {
                WebcamFeed.Source = BitmapToImageSource(_currentFrame);
            });
        }

        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }



        private async void CaptureAndSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentFrame == null || (string.IsNullOrWhiteSpace(FNameTextBox.Text) && string.IsNullOrWhiteSpace(LNameTextBox.Text)))
            {
                MessageBox.Show("Ensure the webcam is active and first name & last name is entered.");
                return;
            }
            var user = new UserST
            {
                Id = new Random().Next(100, 2000),
                FirstName = FNameTextBox.Text.ToUpper(),
                LastName = LNameTextBox.Text.ToUpper(),
                DepartmentId =  SelectedItemId
                
            };

            try
            {
                string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WebcamImages");
                Directory.CreateDirectory(directory);

                string imagePath = Path.Combine(directory, $"{Guid.NewGuid()}.jpg");
                _currentFrame.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                var checkuser = await _mongoDataProvider.GetByIdAsync(user.Id);
                if (checkuser == null)
                {
                    user.ImagePath = imagePath;
                    await _mongoDataProvider.InsertAsync(user);
                    MessageBox.Show("User added successfully!");
                    //ShutdownWebcam();
                    //var myProfile = new Page.CreateUser();
                    //myProfile.Close();

                    //OnClosed(e);

                }
                else
                {
                    var userId = 0;
                    userId = user.Id + 1;
                    user.Id = userId;
                    user.ImagePath = imagePath;
                    await _mongoDataProvider.InsertAsync(user);
                    MessageBox.Show("User added successfully!");
                    OnClosed(e);

                    //MessageBox.Show("User Already exists!");
                }
                //ClearInputs();
                //await LoadDepartmentsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);
        //    if (_videoSource != null && _videoSource.IsRunning)
        //    {
        //        _videoSource.SignalToStop();
        //        _videoSource.WaitForStop();
        //    }
        //}

        private async System.Threading.Tasks.Task LoadDepartmentsAsync()
        {
            try
            {
                List<Department> items = (List<Department>)await _departmongoDataProvider.GetAllAsync();
                DepartmentcomboBox.ItemsSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            var myProfile = new Page.CreateUser();
            myProfile.Close();
        }

        private void ShutdownButton_Click(object sender, RoutedEventArgs e)
        {
              ShutdownWebcam();
        }
        // Detect Ctrl+X key press
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.X && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                ShutdownWebcam();
            }
        }


        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //base.OnClosing(e);
            ShutdownWebcam();
        }

        private void ShutdownWebcam()
        {
            if (_videoSource != null && _videoSource.IsRunning)
            {                                                                                           v
                _videoSource.SignalToStop();
                _videoSource.WaitForStop();
                _videoSource = null;
            }

            MessageBox.Show("Webcam shutdown.");
        }

       
    }
}
