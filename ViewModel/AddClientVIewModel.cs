using clientcheck.Commands;
using clientcheck.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using static clientcheck.Model.ModelManager;

namespace clientcheck.ViewModel
{
    class AddClientVIewModel

    {
        
        public ICommand AddClientCommand { get; set; }

        public static string newName { get; set; }
        public static  string newAge { get; set; }
        public static string newPhonenumb { get; set; }
        

        public AddClientVIewModel()
        {
            AddClientCommand = new RelayCommand(AddClient, CanAddClient);

        }

        private bool CanAddClient(object obj)
        {//어떠한 경우에라도 true. 조건은 AddClient.
            return true;
        }

        private void AddClient(object obj)
        {
            try
            {
                bool isphonenumb = Regex.IsMatch(newPhonenumb, @"^\d{3}-\d{4}-\d{4}$");

                bool isNumeric = int.TryParse(newAge, out int result);
                //형식, 빈칸등이 조건에 맞아야만 AddClient시행
                if (!string.IsNullOrWhiteSpace(newName) && (!string.IsNullOrWhiteSpace(newAge)) && !string.IsNullOrWhiteSpace(newPhonenumb) && isphonenumb && isNumeric)
                { ModelManager.AddClient(new client() { Name = newName, Age = newAge, Phonenumb = newPhonenumb, delete = true }); }
            }
            catch { Debug.WriteLine("AddClient오류"); }
        }
    }
}
