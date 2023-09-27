using clientcheck.Commands;
using clientcheck.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static clientcheck.Model.ModelManager;

namespace clientcheck.ViewModel
{
    class AddClientVIewModel

    {
        public ICommand AddClientCommand { get; set; }

        public string newName { get; set; }
        public string newAge { get; set; }
        public string newPhonenumb { get; set; }
        

        public AddClientVIewModel()
        {
            AddClientCommand = new RelayCommand(AddClient, CanAddClient);

        }

        private bool CanAddClient(object obj)
        {
            return true;
        }

        private void AddClient(object obj)
        {
            if (!string.IsNullOrWhiteSpace(newName) && (!string.IsNullOrWhiteSpace(newAge)) && !string.IsNullOrWhiteSpace(newPhonenumb))
            { ModelManager.AddClient(new client() { Name = newName, Age = newAge, Phonenumb = newPhonenumb, delete = true }); }
        }
    }
}
