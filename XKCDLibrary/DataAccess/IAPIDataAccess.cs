using System.Threading.Tasks;
using XKCDLibrary.Models;

namespace XKCDLibrary.DataAccess
{
    public interface IAPIDataAccess
    {
        public const string XKCD_URL = "https://xkcd.com/";
        public const string XKCD_URL_END = "/info.0.json";
        public const string XKCD_MOST_RECENT_URL = "https://xkcd.com/info.0.json";
        Task<Comic> Get(string url);
    }
}