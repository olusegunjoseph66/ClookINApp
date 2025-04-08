using ClockINVerraki.DbContext;
using ClockINVerraki.Models;
using ClockINVerraki.ViewModels;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
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

namespace ClockINVerraki.Page
{
    /// <summary>
    /// Interaction logic for ClockINlist.xaml
    /// </summary>
    public partial class ClockINlist : Window
    {
        private readonly ClockinDBContext<ClockUser> _mongoDataProvider;
        private readonly ClockinDBContext<Department> _departmongoDataProvider;

        public ClockINlist()
        {
            InitializeComponent();


            string connectionString = "mongodb://localhost:27017";
            string databaseName = "DemoDatabase";
            //string collectionName = "Departments";

            //_mongoDataProvider = new ClockinDBContext<Department>(connectionString, databaseName, collectionName);
            _mongoDataProvider = new ClockinDBContext<ClockUser>(connectionString, databaseName, "ClockUsers");
            _departmongoDataProvider = new ClockinDBContext<Department>(connectionString, databaseName, "Departments");

            LoadClockInsAsync();

            DataContext = this;
        }

        private async System.Threading.Tasks.Task<List<ClockinDto>> LoadClockInsAsync()
        {
            try
            {
                List<ClockinDto> clockDtos = new List<ClockinDto>();
                //ClockinDto userclock;
                // ObservableCollection<UserST> items = (ObservableCollection<UserST>)await _mongoDataProvider.GetAllAsync();
                List<ClockUser> items = (List<ClockUser>)await _mongoDataProvider.GetAllAsync();
                foreach (var useritem in items)
                {
                    if (useritem.DepartmentId.HasValue)
                    {
                        var dept = await _departmongoDataProvider.GetByIdAsync(useritem.DepartmentId.Value);

                        var userclock = new ClockinDto
                        {
                            Id = useritem.Id,
                            UserId = useritem.UserId,
                            GetTime = useritem.GetTime,
                            IsStaff = useritem.IsStaff,
                            DepartmentName = dept.Name
                        };
                        clockDtos.Add(userclock);
                    }
                    else
                    {
                        var userclock = new ClockinDto
                        {
                            Id = useritem.Id,
                            UserId = useritem.UserId,
                            GetTime = useritem.GetTime,
                            IsStaff = useritem.IsStaff
                            //DepartmentName = dept.Name
                        };
                        clockDtos.Add(userclock);
                    }
                       

                    
                }

                //Users = (List<UserST>)await _mongoDataProvider.GetAllAsync();



                ClockinsListView.ItemsSource = clockDtos.OrderByDescending(i => i.GetTime);

                return clockDtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
                return new List<ClockinDto>();
            }
        }

        private async System.Threading.Tasks.Task<List<ClockinDto>> LoadClockInsAsync(string start, string stop)
        {
            try
            {
                List<ClockinDto> clockDtos = new List<ClockinDto>();
                //ClockinDto userclock;  .Date <= filter.ToDate.Value.Date             .Date >= filter.FromDate.Value.Date
                // ObservableCollection<UserST> items = (ObservableCollection<UserST>)await _mongoDataProvider.GetAllAsync();
                List<ClockUser> items = (List<ClockUser>)await _mongoDataProvider.GetAllAsync();

                var startdate = DateTime.Parse(start);
                var stopdate = DateTime.Parse(stop);

                var itms = items.Where(i => i.GetTime.Date >= startdate.Date && i.GetTime.Date <= stopdate.Date);

                foreach (var useritem in itms)
                {
                    if (useritem.DepartmentId.HasValue)
                    {
                        var dept = await _departmongoDataProvider.GetByIdAsync(useritem.DepartmentId.Value);

                        var userclock = new ClockinDto
                        {
                            Id = useritem.Id,
                            UserId = useritem.UserId,
                            GetTime = useritem.GetTime,
                            IsStaff = useritem.IsStaff,
                            DepartmentName = dept.Name
                        };
                        clockDtos.Add(userclock);
                    }
                    else
                    {
                        var userclock = new ClockinDto
                        {
                            Id = useritem.Id,
                            UserId = useritem.UserId,
                            GetTime = useritem.GetTime,
                            IsStaff = useritem.IsStaff
                            //DepartmentName = dept.Name
                        };
                        clockDtos.Add(userclock);
                    }



                }

                //Users = (List<UserST>)await _mongoDataProvider.GetAllAsync();



                ClockinsListView.ItemsSource = clockDtos.OrderByDescending(i => i.GetTime);

                return clockDtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading items: " + ex.Message);
                return new List<ClockinDto>();
            }
        }

        private async void ExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            //string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ClockINRecords.xlsx");

            try
            {
                List<ClockinDto> records;
                // Fetch MongoDB records
                if (StartTextBox != null)
                {
                    records = await LoadClockInsAsync(StartTextBox.Text, StopTextBox.Text);
                }
                else
                {
                    records = await LoadClockInsAsync();
                }                     


                if (records.Count == 0)
                {
                    StatusTextBlock.Text = "No records found to export.";
                    return;
                }

                // Create an Excel file
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Export");

                // Add headers
                worksheet.Cell(1, 1).Value = "UserId";
                worksheet.Cell(1, 2).Value = "IsStaff";
                worksheet.Cell(1, 3).Value = "GetTime";
                worksheet.Cell(1, 4).Value = "DepartmentName";

                // Add data
                for (int i = 0; i < records.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = records[i].UserId;
                    worksheet.Cell(i + 2, 2).Value = records[i].IsStaff;
                    worksheet.Cell(i + 2, 3).Value = records[i].GetTime;
                    worksheet.Cell(i + 2, 4).Value = records[i]?.DepartmentName;    //? records[i].DepartmentName.ToString() : "" ;
                }

                // Save Excel file
                string folderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ClockINRecords.xlsx");
                workbook.SaveAs(folderPath);

                StatusTextBlock.Text = $"Export successful! File saved at: {folderPath}";

                //using (var package = new ExcelPackage())
                //{
                //    //using XLWorkbook? workbook = new();
                //    //IXLWorksheet worksheet =
                //    //workbook.Worksheets.Add("Records");
                //    //worksheet.Cell(1, 1).Value = "UserId";
                //    //worksheet.Cell(1, 2).Value = "IsStaff";
                //    //worksheet.Cell(1, 3).Value = "GetTime";
                //    //worksheet.Cell(1, 4).Value = "DepartmentName";

                //    //var worksheet = package.Workbook.Worksheets.Add("Records");

                //    // Add headers
                //    //worksheet.Cells[1, 1].Value = "UserId";
                //    //worksheet.Cells[1, 2].Value = "IsStaff";
                //    //worksheet.Cells[1, 3].Value = "GetTime";
                //    //worksheet.Cells[1, 4].Value = "DepartmentName";

                //    // Add data
                //    //for (int index = 1; index <= records.Count; index++)
                //    //{
                //    //    worksheet.Cell(index + 1, 1).Value = records[index - 1].UserId;
                //    //    worksheet.Cell(index + 1, 2).Value = records[index - 1].IsStaff;
                //    //    worksheet.Cell(index + 1, 3).Value = records[index - 1].GetTime;
                //    //    worksheet.Cell(index + 1, 4).Value = records[index - 1].DepartmentName;
                //    //worksheet.Cells[i + 2, 1].Value = records[i]["_id"].ToString();
                //    //worksheet.Cells[i + 2, 2].Value = records[i].Contains("Text") ? records[i]["Text"].ToString() : "";
                //    //worksheet.Cells[i + 2, 3].Value = records[i].Contains("Timestamp") ? records[i]["Timestamp"].ToUniversalTime().ToString() : "";

                //    //}
                //    for (int i = 0; i < records.Count; i++)
                //    {
                //        //worksheet.Cells(i + 1, 1).Value = records[i - 1].Id;
                //        //worksheet.Cells[i + 2, 1].Value = records[i]["UserId"].ToString();
                //        //worksheet.Cells[i + 2, 2].Value = records[i].Contains("DepartmentName") ? records[i]["DepartmentName"].ToString() : "";
                //        //worksheet.Cells[i + 2, 3].Value = records[i].Contains("Timestamp") ? records[i]["Timestamp"].ToUniversalTime().ToString() : "";

                //        worksheet.Cells[i + 2, 1].Value = records[i].UserId; //["UserId"].ToString(); Contains("IsStaff")
                //        worksheet.Cells[i + 2, 2].Value = records[i].IsStaff; //? records[i - 1].IsStaff.ToString() : "";
                //        worksheet.Cells[i + 2, 3].Value = records[i].GetTime.ToUniversalTime().ToString();//? records[i - 1].GetTime.ToUniversalTime().ToString() : "";
                //        //worksheet.Cells[i + 2, 4].Value = records[i].DepartmentName.ToString();

                //    }

                //    // Save to disk
                //    File.WriteAllBytes(filePath, package.GetAsByteArray());
                //}

                //StatusTextBlock.Text = $"Exported to {filePath}";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Error: " + ex.Message;
            }

        }

        private void DatePickerCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (DatePickerCalendar.SelectedDate.HasValue)
            {
                // Update the TextBox with the selected date
                StartTextBox.Text = DatePickerCalendar.SelectedDate.Value.ToString("yyyy-MM-dd");
                // Hide the Calendar after selection
                DatePickerCalendar.Visibility = Visibility.Collapsed;
            }
        }

        private void StartTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            DatePickerCalendar.Visibility = Visibility.Visible;
        }

        private void StopTextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            StopDatePickerCalendar.Visibility = Visibility.Visible;
        }

        private void StopDatePickerCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (StopDatePickerCalendar.SelectedDate.HasValue)
            {
                // Update the TextBox with the selected date
                StopTextBox.Text = StopDatePickerCalendar.SelectedDate.Value.ToString("yyyy-MM-dd");
                // Hide the Calendar after selection
                StopDatePickerCalendar.Visibility = Visibility.Collapsed;
            }
        }

       
    }
}
