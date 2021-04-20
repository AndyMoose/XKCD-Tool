using System.Threading.Tasks;
using XKCDLibrary.Models;

namespace XKCDLibrary.DataAccess
{
    public interface IAPIDataAccess
    {       
        Task<ComicModel> Get(string url);
    }
}