using System.Collections.Generic;
using System.Threading.Tasks;
using XKCDLibrary.Models;

namespace XKCDLibrary.DataAccess
{
    public interface IDBDataAccess
    {
        List<int> SavedComicList { get; set; }
        List<int> UnsavedComicList { get; set; }
        Task<Comic> Delete(Comic xkcd);
        Task<Comic> Insert(Comic xkcd);
        Task<List<Comic>> GetListofSavedComics();
    }
}