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
        public ICommand DeleteClientCommand { get; set; }

        public string DelName { get; set; }
        public string DelAge { get; set; }
        public string DelPhonenumb { get; set; }


        public ICommand ShowWindowCommand { get; set; }
     



        public Viewmodelmanger()
        {
            ModelManager newone = new ModelManager();
            ClientLists = GetClients();
            ShowWindowCommand = new RelayCommand(ShowWindow, CanshowWindow);

            DeleteClientCommand = new RelayCommand(DeleteClient, CanDeleteClient);

        }

        private bool CanDeleteClient(object obj)
        {
            return true;
        }

        private void DeleteClient(object obj)
        {
            {

                IEnumerable<client> selectedClients = ClientList.Where(c => c.IsSelected);
                ObservableCollection<client> selectedClientsCollection = new ObservableCollection<client>(selectedClients);
                foreach (client client in selectedClientsCollection)
                {
                    Debug.WriteLine(client);
                    ModelManager.DeleteClient(client);
                  
                }

                
            }
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
