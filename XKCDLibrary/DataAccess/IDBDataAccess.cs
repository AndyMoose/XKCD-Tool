using System.Collections.Generic;
using System.Threading.Tasks;
using XKCDLibrary.Models;

namespace XKCDLibrary.DataAccess
{
    public interface IDBDataAccess
    {
        List<int> SavedComicList { get; set; }
        Task<ComicModel> Delete(ComicModel xkcd);
        Task<ComicModel> Insert(ComicModel xkcd);
        Task<List<ComicModel>> GetListofSavedComics();
    }
}