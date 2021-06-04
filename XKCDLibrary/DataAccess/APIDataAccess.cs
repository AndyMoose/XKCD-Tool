using System.Net.Http;
using System.Threading.Tasks;
using XKCDLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace XKCDLibrary.DataAccess
{
    public class APIDataAccess : IAPIDataAccess
    {
        public const string XKCD_URL = "https://xkcd.com/";
        public const string XKCD_URL_END = "/info.0.json";
        public const string XKCD_MOST_RECENT_URL = "https://xkcd.com/info.0.json";

        public static int XKCD_MOST_RECENT_COMIC_NUMBER { get; set; }

        private static HttpClient _client;

        public async Task Initialize()
        {
            _client = new HttpClient();
            _client.Timeout = TimeSpan.FromSeconds(10);

            var comic = await Get(XKCD_MOST_RECENT_URL);
            XKCD_MOST_RECENT_COMIC_NUMBER = comic.Num;
        }
       

        public async Task<Comic> Get(string url)
        {
            try
            {
                string json = null;

                json = await _client.GetStringAsync(url);               

                return JsonConvert.DeserializeObject<Comic>(json);
            }
            catch
            {
                MessageBox.Show("Unable to connect to XKCD.  Please check your internet connection.");

                throw;
            }

        }
    }
}
