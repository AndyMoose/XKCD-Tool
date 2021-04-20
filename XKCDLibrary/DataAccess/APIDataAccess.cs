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
