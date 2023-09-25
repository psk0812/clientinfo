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
            
            Border dashdotdot = FindName("dashdotdot") as Border;

            if (dashdotdot != null)
            {
               
                LinearGradientBrush borderBrush = new LinearGradientBrush();
                borderBrush.StartPoint = new Point(0, 1);
                borderBrush.EndPoint = new Point(1, 0);
                borderBrush.GradientStops.Add(new GradientStop(Colors.RoyalBlue, 0));
                borderBrush.GradientStops.Add(new GradientStop(Colors.HotPink, 0.85));

               
                Pen borderPen = new Pen(borderBrush, 10);
                borderPen.DashStyle = new DashStyle(new double[] { 2, 2, 2, 2 }, 0);
                borderPen.DashCap = PenLineCap.Triangle;

               
            }

            Color UIblue = Color.FromRgb(0, 100, 245);
            Height = SystemParameters.PrimaryScreenHeight;


            //화면 기준 가로 세로 비율 4:3, 세로 기준 화면 크기의 0.7이 기본이 되도록
            this.Width = Height * 0.7 / 6 * 8; ;
            this.Height = Height * 0.7;
        }

        private void titlebar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void titlebar1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        private void titlebar3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }

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
    }
     
 }
