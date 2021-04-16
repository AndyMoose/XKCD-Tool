using System.Net.Http;
using System.Threading.Tasks;
using XKCDLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace XKCDLibrary.DataAccess
{
    public class APIDataAccess
    {

        public ComicModel Xkcd { get; set; }

        internal async Task<ComicModel> Get(string url)
        {
            try
            {
                string json = null;

                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);
                    json = await client.GetStringAsync(url);
                }

                Xkcd = JsonConvert.DeserializeObject<ComicModel>(json);

                return Xkcd;
            }
            catch
            {
                MessageBox.Show("Unable to connect to XKCD.  Please check your internet connection.");

                return null;
            }
           
        }

    }
}
