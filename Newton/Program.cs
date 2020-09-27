using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;



namespace Newton
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


                //var testClass = JsonConvert.DeserializeObject<Welcome>(response);

                List<Welcome> test = JsonConvert.DeserializeObject<List<Welcome>>(response);

                foreach (Welcome item in test)
                    Console.WriteLine(item.Id);
                //Console.WriteLine(test);
                Console.ReadKey();
            }
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