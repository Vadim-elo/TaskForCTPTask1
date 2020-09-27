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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using Excel = Microsoft.Office.Interop.Excel;

namespace ListBoxOfJSON
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Welcome> test = null;
        public MainWindow()
        {
            InitializeComponent();

            string url = "https://jsonplaceholder.typicode.com/posts";
            // Создаём объект WebClient
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response = webClient.DownloadString(url);


                //var testClass = JsonConvert.DeserializeObject<Welcome>(response);

                test = JsonConvert.DeserializeObject<List<Welcome>>(response);

                string item_get = null;
                foreach (Welcome item in test)
                {
                    item_get = "UserId: " + item.UserId + "\nId: " + item.Id + "\nTitle: " + item.Title + "\nBody: " + item.Body;
                    ListBox1.Items.Add(item_get);
                }
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application xlApp = new Excel.Application(); //Excel//Excel
            Excel.Workbook xlWB; //рабочая книга
            Excel.Worksheet xlSht; //лист Excel
            object misValue = System.Reflection.Missing.Value;

            xlWB = xlApp.Workbooks.Add(misValue);
            xlSht = (Excel.Worksheet)xlWB.Worksheets.get_Item(1);




            string item_get = null;
            int countItem = 1;
            foreach (Welcome item in test)
            {
                if (Convert.ToInt32(GetUserTextBox.Text) == item.UserId)
                {
                    xlSht.Cells[countItem,1] = item.Title;
                    xlSht.Cells[countItem+1,1] = item.Body;
                    xlSht.Cells[countItem+2,1] = "";
                    countItem += 3;
                }
                //item_get = "UserId: " + item.UserId + "\nId: " + item.Id + "\nTitle: " + item.Title + "\nBody: " + item.Body;
                //ListBox1.Items.Add(item_get);
            }
            xlSht.Name = "Data of UserId = " + GetUserTextBox.Text;

            string nameOfFile = "d:\\ExcelData-of-user-by-Id-" + GetUserTextBox.Text+ ".xls";
            xlWB.SaveAs(nameOfFile, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWB.Close(true, misValue, misValue);
            xlApp.Quit();

            //xlApp.Visible = true;
        }
    }
    public partial class Welcome
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
