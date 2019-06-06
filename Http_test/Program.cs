using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Http_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string Url = "http://10.10.61.251:9090/v1/motions";

            string Data = "{\"motion\": {\"direction\": \"left\",\"name\": \"raise\",  \"repeat\": 4, \"speed\": \"normal\" }, \"operation\": \"start\", \"timestamp\":1551838515 }";

            Console.WriteLine("Start Http test ...");

            HttpContent httpContent = new StringContent(Data);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };

            var httpClient = new HttpClient();
            HttpResponseMessage response = httpClient.PutAsync(Url, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
              string result = response.Content.ReadAsStringAsync().Result;
              Console.Write("Success result is : {0}",result);
            }
           
            Console.WriteLine("Http test done!");
            Console.ReadKey();
        }
    }
}
