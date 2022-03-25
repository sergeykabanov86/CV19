using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_deaths_US.csv";

            //WebClient client = new WebClient(); depricated version
            //var items = new string[10];
            //var lastItem = items[^1];     //обратная индексация в net.Core

            //var client = new HttpClient();
            //var response = client.GetAsync(url).Result;
            //var csv = response.Content.ReadAsStringAsync().Result;

            //Читаем из файла
            var csv = System.IO.File.ReadAllText(@"d:\Programming\VS2019Projects\CS\Wpf\CV19\hoopkins_data.csv");



            Console.ReadKey();

        }
    }
}
