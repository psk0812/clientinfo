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
using System.Collections.ObjectModel;

using clientcheck.ViewModel;

using clientcheck.Model;
using static clientcheck.Model.ModelManager;
using System.Diagnostics;

namespace clientcheck.View
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
            Viewmodelmanger newviewmodel = new Viewmodelmanger();
            DataContext = newviewmodel;

            Height = SystemParameters.PrimaryScreenHeight;


            //화면 기준 가로 세로 비율 4:3, 세로 기준 화면 크기의 0.7이 기본이 되도록
            this.Width = Height * 0.7 / 6 * 8; ;
            this.Height = Height * 0.7;
        }

       

        private void minimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void maximize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            { this.WindowState = WindowState.Normal; }
            else { this.WindowState = WindowState.Maximized; }
           
        }

        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void namebox_GotFocus(object sender, RoutedEventArgs e)
        {
            namebox.Text = String.Empty;
           

        }

        private void agebox_GotFocus(object sender, RoutedEventArgs e)
        {
           

            agebox.Text = String.Empty;
        }

       

      

    

        private void btn_add_Click_1(object sender, RoutedEventArgs e)
        {
            plus pluswindow = new plus();
            pluswindow.ShowDialog(); 


        }

    

       

   


        private void btn_find_Click(object sender, RoutedEventArgs e)
        {
            string nameFilter = namebox.Text;
            string ageFilter = agebox.Text;

            // 디자인으로 넣어넣은 글씨가 필터링 될 오류 제거
            if (nameFilter == "Name")
            { nameFilter = ""; }
            if (ageFilter == "Age")
            { ageFilter = ""; }

            
             var filteredClients = ClientList.Where(client =>
                    (string.IsNullOrEmpty(nameFilter) || client.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(ageFilter) || client.Age.ToString().Contains(ageFilter))
                ).ToList();

            datagrid_client.ItemsSource = filteredClients;
           
        }

    

        private void btndelete_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Button clickedButton = (Button)sender;
            // 클릭된 버튼을 포함한 행을 찾습니다.
            DependencyObject depObj = (DependencyObject)sender;

            Debug.Write("클릭성공");
            while (!(depObj is DataGridRow) && depObj != null)
            {
                depObj = VisualTreeHelper.GetParent(depObj);
            }

            // 찾은 DataGridRow를 사용합니다.
            if (depObj is DataGridRow dataGridRow)
            {
                // 해당 행의 데이터에 액세스합니다.
                client rowData = (client)dataGridRow.DataContext;


                // 각 열의 데이터에 접근할 수 있습니다.
                Viewmodelmanger.delName = rowData.Name;
                Viewmodelmanger.delAge = rowData.Age;
                Viewmodelmanger.delPhonenumb = rowData.Phonenumb;

                Debug.Write(rowData.Name);

                // 필요한 데이터를 사용하여 작업을 수행합니다.
            };


        }

      
    }
     
 }
