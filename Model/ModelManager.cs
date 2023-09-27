using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace clientcheck.Model
{
    public class ModelManager
    {

        int count = 0;

        bool for_topten;//처음에 만든 10개만 삭제 안하게 하기 위함.
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
            try
            {
                ClientList.Add(client1);
                SaveDataToCSV();
                System.Threading.Thread.Sleep(1000); // 1초 대기
            }
            catch (Exception ex) 
            {
                Debug.WriteLine("AddClient에러");
            }
        }


        public static void DeleteClient(client client1)
        {
            try
            {

                var clientToDelete = ClientList.FirstOrDefault(c =>
                c.Name == client1.Name &&
                c.Age == client1.Age &&
                c.Phonenumb == client1.Phonenumb &&
                c.delete == client1.delete);
                if (clientToDelete != null)
                {

                    ClientList.Remove(clientToDelete);
                }
                SaveDataToCSV();
                System.Threading.Thread.Sleep(1000); // 1초 대기
            }
            catch (Exception ex)
            {
                Debug.WriteLine("DeleteClient에러");
            }

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
                using (var sr = new StreamReader("D:/notdie/client_finish/Model/data.csv", Encoding.Default)) // 인코딩을 UTF-8로 설정
                using (var parser = new TextFieldParser(sr))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        count += 1;

                        if (count <= 10) { for_topten = false; }
                        else { for_topten = true; }
                        client newClient = new client
                        {
                          
                            Name = fields[0],
                            Age = fields[1],
                            Phonenumb = fields[2],
                            delete = for_topten
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

        public static void SaveDataToCSV()
        {
            try
            {
                Debug.WriteLine("저장");
                using (var sw = new StreamWriter("D:/notdie/client_finish/Model/data.csv", false, Encoding.Default)) // 인코딩을 UTF-8로 설정
                {
                    foreach (var client in ClientList)
                    {
                        Debug.WriteLine($"{client.Name},{client.Age},{client.Phonenumb},{client.delete}");
                        string csvLine = $"{client.Name},{client.Age},{client.Phonenumb},{client.delete}";
                        sw.WriteLine(csvLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CSV 파일을 저장하는 동안 오류가 발생했습니다: " + ex.Message);
            }
        }


        public static ObservableCollection<client> GetClients()
        {
            return ClientList;
        }
    } 
} 
