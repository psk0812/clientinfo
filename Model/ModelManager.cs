using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace clientcheck.Model
{
    public class ModelManager
    {
     

        public static ObservableCollection<client> ClientList { get; set; }


        public class client
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string Phonenumb { get; set; }
            public bool delete { get; set; }
        }

        public static void AddClient(client client1)
        {
            ClientList.Add(client1);
        }

        


        public ModelManager()
        {
            ClientList = new ObservableCollection<client>();
            LoadDataFromCSV();
        }

        

        public void LoadDataFromCSV()
        {
            try
            {
                using (var sr = new StreamReader("D:/notdie/client/Model/data.csv", Encoding.Default)) // 인코딩을 UTF-8로 설정
                using (var parser = new TextFieldParser(sr))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        client newClient = new client
                        {
                            Name = fields[0],
                            Age = fields[1],
                            Phonenumb = fields[2],
                            delete = false // 기본값으로 설정
                        };

                        ClientList.Add(newClient);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CSV 파일을 불러오는 동안 오류가 발생했습니다: " + ex.Message);
            }
        }

        public static ObservableCollection<client> GetClients()
        {
            return ClientList;
        }
    } 
} 
