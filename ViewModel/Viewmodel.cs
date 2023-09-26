using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static clientcheck.Model.Model;

namespace clientcheck.ViewModel
{
    public class Viewmodel
    {
        public ObservableCollection<client> ClientLists { get; set; }
  

        public Viewmodel()
        {
            ClientLists = new ObservableCollection <client>
            {
                new client { Name = "박민준", Age = 23, Phonenumb = "010-5496-5056" },
                new client { Name = "박서준", Age = 28, Phonenumb = "010-1234-5678" },
                new client { Name = "이홍비", Age = 30, Phonenumb = "010-9876-5432" },
                new client { Name = "김예준", Age = 23, Phonenumb = "010-5496-5056" },
                new client { Name = "이하운", Age = 28, Phonenumb = "010-1234-5678" },
                new client { Name = "제갈공명", Age = 30, Phonenumb = "010-9876-5432" },
                new client { Name = "송채원", Age = 23, Phonenumb = "010-4690-9633" },
                new client { Name = "석준", Age = 28, Phonenumb = "010-9657-3248" },
                new client { Name = "이건후", Age = 30, Phonenumb = "010-3793-4615" },
                new client { Name = "이히힉", Age = 30, Phonenumb = "010-3793-4615" }
            };
        }
    }
}
