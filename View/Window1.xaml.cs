﻿using System;
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
            this.DataContext = newviewmodel;

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

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_add_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Button_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btn_add_Click_1(object sender, RoutedEventArgs e)
        {
            plus pluswindow = new plus();
            pluswindow.ShowDialog(); 
        }

    

       

   
        private void btn_plus_Click(object sender, RoutedEventArgs e)
        {
            string nameFilter = namebox.Text;
            string ageFilter = agebox.Text;

            // 디자인으로 넣어넣은 글씨가 필터링 될 오류 제거
            if (nameFilter == "Nmae")
            { nameFilter = ""; }
            if (nameFilter == "Age")
            { nameFilter = ""; }

            var filteredClients = ClientList.Where(client =>
                (string.IsNullOrEmpty(nameFilter) || client.Name.Contains(nameFilter, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(ageFilter) || client.Age.ToString().Contains(ageFilter))
            ).ToList();

            datagrid_client.ItemsSource = filteredClients;


        }
    }
     
 }
