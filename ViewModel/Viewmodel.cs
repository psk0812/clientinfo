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
using static clientcheck.Model.Model;

namespace clientcheck.ViewModel
{
    public class Viewmodel
    {
        public ObservableCollection<client> ClientLists { get; set; }
  

        public Viewmodel()
        {
            ClientLists = new ObservableCollection<client>(); 
            LoadDataFromCSV();
        }
        public void LoadDataFromCSV()
        {
            try
            {
                using (var sr = new StreamReader("D:/notdie/clientcheck/Model/data.csv", Encoding.Default)) // 인코딩을 UTF-8로 설정
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
                            Age = int.Parse(fields[1]),
                            Phonenumb = fields[2],
                            delete = false // 기본값으로 설정
                        };

                        ClientLists.Add(newClient);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CSV 파일을 불러오는 동안 오류가 발생했습니다: " + ex.Message);
            }
        }

    }
}
