using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestTaskCTP
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            // Создаём объект WebClient
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response = webClient.DownloadString(url);

                var testClass = JsonConvert.<Class1>(response);

                Console.WriteLine(testClass);
                Console.ReadKey();
            }

        }
    }
    public class ClassOfDeserialize_JSON
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }

        public string body { get; set; }
    }

    public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

    public class Class1
        {
            public int userId { get; set; }
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }

    
}
