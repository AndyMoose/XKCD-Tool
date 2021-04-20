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

        public APIDataAccess()
        {
            Initialize();
        }

        private async void Initialize()
        {
            var comic = await Get(XKCD_MOST_RECENT_URL);
            XKCD_MOST_RECENT_COMIC_NUMBER = comic.Num;
        }
       

        public async Task<ComicModel> Get(string url)
        {
            try
            {
                string json = null;

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);
                    json = await client.GetStringAsync(url);
                }

                return JsonConvert.DeserializeObject<ComicModel>(json);
            }
            catch
            {
                MessageBox.Show("Unable to connect to XKCD.  Please check your internet connection.");

                return null;
            }

        }
    }
}
