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


            //화면 기준 가로 세로 비율 4:3, 세로 기준 화면 크기의 0.7이 기본이 되도록
            Height = SystemParameters.PrimaryScreenHeight;
            this.Width = Height * 0.7 / 6 * 8; ;
            this.Height = Height * 0.7;
        }


        //타이틀바의 최소화 버튼
        private void minimize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch { Debug.WriteLine(" minimize_MouseDown에러 "); }
        }
        //타이틀바의 화면 닫기 버튼
        private void exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //타이틀바의 화면 최대 버튼
        private void maximize_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (this.WindowState == WindowState.Maximized)
                { this.WindowState = WindowState.Normal; }
                else { this.WindowState = WindowState.Maximized; }
            }
            catch { Debug.WriteLine("maximize_MouseDown 에러"); }

        }


        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();//타이틀바로 드래그 가능
            }
            catch { Debug.WriteLine("DragMove() 에러"); }
        }



        private void namebox_GotFocus(object sender, RoutedEventArgs e)//조회에서 이름을 클릭하면 기존의 글자가 지워짐
        {
            try
            {
                namebox.Text = String.Empty;
            }
            catch { Debug.WriteLine("namebox_GotFocus 에러"); }

        }

        private void agebox_GotFocus(object sender, RoutedEventArgs e)//기존의 글자가 지워짐
        {
            try
            {

                agebox.Text = String.Empty;
            }
            catch { Debug.WriteLine("agebox_GotFocus 에러"); }
        }







        private async void btn_add_Click_1(object sender, RoutedEventArgs e)//멤버 추가 버튼
        {
            try
            {
                plus pluswindow = new plus();

                pluswindow.ShowDialog();

                await Task.Delay(200);
                filtered_upgradeAsync(); //필터된 상태에서도 추가를 바로 볼수 있음
            }
            catch { Debug.WriteLine("btn_add_Click_1 에러"); }

        }







        private async void btn_find_Click(object sender, RoutedEventArgs e)//멤버 죄회버튼
        {
            try
            {

                await Task.Delay(200);//한번에 1000하니 너무 김
                filtered_upgradeAsync();

            }
            catch { Debug.WriteLine("btn_find_Click 에러"); }

        }


        private async void filtered_upgradeAsync() //필터링 수행
        {
            try
            {
                string nameFilter = namebox.Text;
                string ageFilter = agebox.Text;

                // 디자인으로 넣어넣은 글씨가 필터에 사용되는 오류 제거
                if (nameFilter == "Name")
                { nameFilter = ""; }
                if (ageFilter == "Age")
                { ageFilter = ""; }

                //조건에 맞는 데이터만 뽑아냄
                var filteredClients = ClientList.Where(client =>
                       (string.IsNullOrEmpty(nameFilter) || client.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase)) &&
                       (string.IsNullOrEmpty(ageFilter) || client.Age.ToString().Contains(ageFilter))
                   ).ToList();

                datagrid_client.ItemsSource = filteredClients;
                await Task.Delay(1000);
            }
            catch { Debug.WriteLine("filtered_upgradeAsync() 에러"); }




        }
        private async void btndelete_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Button clickedButton = (Button)sender;
                // 클릭된 버튼을 포함한 행찾기 시작
                DependencyObject depObj = (DependencyObject)sender;

                Debug.Write("클릭성공");
                while (!(depObj is DataGridRow) && depObj != null)
                {
                    depObj = VisualTreeHelper.GetParent(depObj); //버튼이 크릭된 행의 데이터를 가져옴
                }


                if (depObj is DataGridRow dataGridRow)
                {

                    client rowData = (client)dataGridRow.DataContext;


                    Viewmodelmanger.delName = rowData.Name;
                    Viewmodelmanger.delAge = rowData.Age;
                    Viewmodelmanger.delPhonenumb = rowData.Phonenumb;

                    Debug.Write(rowData.Name);

                    // 필요한 데이터를 사용하여 작업을 수행합니다.
                };
                ;//한번에 1000하니 너무 김
                await Task.Delay(200);
                filtered_upgradeAsync(); //필터된 상태에서도 삭제를 바로 볼수 있음
            }
            catch { Debug.WriteLine("btndelete_MouseDoubleClick 에러"); }

        }


    }

}
