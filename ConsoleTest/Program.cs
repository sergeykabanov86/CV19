using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ConsoleTest
{
    class Program
    {
        const string url = @"https://github.com/CSSEGISandData/COVID-19/raw/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
        const string filePath = @"d:\Programming\VS2019Projects\CS\Wpf\CV19\time_series_covid19_confirmed_global.csv";

        private enum EColumns : int
        {
            Province = 0,
            Country = 1,
            Lat = 2,
            Lon = 3
        }

        #region Internet
        private static async Task<Stream> GetDataStreamNet()
        {
            var client = new HttpClient();
            var resp = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            return await resp.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLinesNet()
        {
            using (var data_stream = GetDataStreamNet().Result)
            {
                using (var data_reader = new StreamReader(data_stream))
                {
                    while (!data_reader.EndOfStream)
                    {
                        var line = data_reader.ReadLine();
                        if (string.IsNullOrEmpty(line)) continue;
                        yield return line.Replace("Bonaire,", "Bonaire -")
                                         .Replace("Helena,", "Helena -")
                                         .Replace("Korea,", "Korea -");
                    }
                }
            }
        }





        private static DateTime[] GetDatesNet() => GetDataLinesNet()
            .First()
            .Split(',')
            .Skip(4)
            .Select(x => DateTime.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();


        private static IEnumerable<(string Country, string Province, double Lat, double Lon, int[] Counts)> GetDataNet()
        {
            var lines = GetDataLinesNet().Skip(1)
                .Select(line => line.Split(','));

            foreach (var row in lines)
            {
                var province = row[(int)EColumns.Province].Trim() ?? string.Empty;
                var country = row[(int)EColumns.Country].Trim(' ', '"') ?? string.Empty;
                var v = row[(int)EColumns.Lat].Replace('.', ',');
                var lat = string.IsNullOrEmpty(row[(int)EColumns.Lat]) ? 0.0 : double.Parse(row[(int)EColumns.Lat].Replace('.', ','));
                var lon = string.IsNullOrEmpty(row[(int)EColumns.Lon]) ? 0.0 : double.Parse(row[(int)EColumns.Lon].Replace('.', ','));
                var counts = row.Skip(4)
                    .Select(x => int.Parse(x))
                    .ToArray();

                yield return (country, province, lat, lon, counts);
            }
        }

        #endregion Internet


        #region File
        private static IEnumerable<string> GetDataLines()
        {
            using (var sr = new StreamReader(File.OpenRead(filePath)))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue;
                    yield return line.Replace("Bonaire,", "Bonaire -")
                                     .Replace("Helena,", "Helena -")
                                     .Replace("Korea,", "Korea -");
                }
            }
        }


        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(x => DateTime.Parse(x, CultureInfo.InvariantCulture))
            .ToArray();

        private static IEnumerable<(string Country, string Province, double Lat, double Lon, int[] Counts)> GetData()
        {
            var rows = GetDataLines().Skip(1)
                                     .Select(row => row.Split(','));

            foreach (var row in rows)
            {
                string country = row[(int)EColumns.Country].Trim(' ', '"') ?? string.Empty;
                string province = row[(int)EColumns.Province].Trim(' ', '"') ?? string.Empty;
                double lat = string.IsNullOrEmpty(row[(int)EColumns.Lat]) ? 0.0 : double.Parse(row[(int)EColumns.Lat].Replace('.', ','));
                double lon = string.IsNullOrEmpty(row[(int)EColumns.Lon]) ? 0.0 : double.Parse(row[(int)EColumns.Lon].Replace('.', ','));
                int[] counts = row.Skip(4)
                                  .Select(c => int.Parse(c))
                                  .ToArray();
                yield return (country, province, lat, lon, counts);
            }
        }
        #endregion File




        static void Main(string[] args)
        {
            #region Internet    
            //var dates = GetDatesNet();
            //Console.WriteLine(string.Join("\r\n", dates));

            //var russia_data = GetDataNet().First(c => c.Country.Equals("Russia", StringComparison.OrdinalIgnoreCase));
            //Console.WriteLine(string.Join("\r\n", GetDatesNet().Zip(russia_data.Counts, (date, count) => $"{date:dd.MM.yyyy}: {count}")));
            #endregion Internet


            #region File

            //var dates = GetDates();
            //Console.WriteLine(string.Join("\r\n", dates));

            var canada_data = GetData().First(x => x.Country.Equals("Canada", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(string.Join("\r\n", GetDates().Zip(canada_data.Counts, (date, count) => $"{date: dd.MM.yyyy}: {count}")));

            #endregion File



            Console.ReadKey();

        }
    }
}
