using clientcheck.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace clientcheck.View
{
    /// <summary>
    /// Window1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class plus : Window
    {
        public plus()
        {
            InitializeComponent();
            AddClientVIewModel addclientviewmodel = new AddClientVIewModel();
            this.DataContext = addclientviewmodel;
            namebox.Text = "";
            agebox.Text = "";
            telbox.Text = "";

        }

 

        //타이틀바로 드래그해서 움직임
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }

            catch { Debug.WriteLine("Grid_MouseDown 에러 "); }
        }


       
        //버튼을 클릭화면 화면 닫힘
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
           
            catch { Debug.WriteLine(" Button_Click에러 "); }
        }
        

      



        private void Button_Click_1(object sender, RoutedEventArgs e)//추가 완료 버튼
        {
            try
            {
                ///000-0000-0000형식
                bool isphonenumb = Regex.IsMatch(telbox.Text, @"^\d{3}-\d{4}-\d{4}$");
                //숫자
                bool isNumeric = int.TryParse(agebox.Text, out int result);


                //빈칸이나 형식에 오류가 있는 경우 닫히지 않고 메시지가 뜸
                if (namebox.Text == "" || agebox.Text == "" || telbox.Text == "" )
                { MessageBox.Show("빈칸을 확인해주세요"); }
                else if (!isNumeric)
                { MessageBox.Show("나이는 숫자로만 입력해주세요"); }
                else if (!isphonenumb)
                { MessageBox.Show("번호 형식을 확인해주세요"); }
                else
                { this.Close(); }
               
        
                
            }
            catch 
            { 
                MessageBox.Show("입력을 확인해주세요"); 
            }
        }




     }
}
