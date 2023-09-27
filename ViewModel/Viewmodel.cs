using clientcheck.Commands;

using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using static clientcheck.Model.ModelManager;
using clientcheck.Model;
using clientcheck.View;
using System.Diagnostics;

namespace clientcheck.ViewModel
{
    public class Viewmodelmanger
    {



        public static ObservableCollection<client> ClientLists { get; set; }
   



        public ICommand ShowWindowCommand { get; set; }
     



        public Viewmodelmanger()
        {
            ModelManager newone = new ModelManager();
            ClientLists = GetClients();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanshowWindow);

       

        }



        private bool CanshowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            plus adduser = new plus();
            adduser.Show();


        }
    }
}
