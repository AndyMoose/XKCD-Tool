using System;
using System.Threading.Tasks;
using XKCDLibrary.Queries;
using XKCDLibrary.Models;
using MediatR;
using System.Threading;
using XKCDLibrary.DataAccess;
using System.Collections.Generic;

namespace XKCDLibrary.Handlers
{
    public class APIRandomComicHandler : IRequestHandler<APIRandomComicQuery, ComicModel>
    {
        private readonly IAPIDataAccess _apidata;
        private readonly IDBDataAccess _dbdata;

        private const string XKCD_URL = "https://xkcd.com/";
        private const string XKCD_URL_END = "/info.0.json";
        private const string XKCD_MOST_RECENT_URL = "https://xkcd.com/info.0.json";

        internal static List<int> UnsavedComicList;

        public APIRandomComicHandler(IAPIDataAccess apidata, IDBDataAccess dbdata)
        {
            _apidata = apidata;
            _dbdata = dbdata;
        }

        public async Task<ComicModel> Handle(APIRandomComicQuery request, CancellationToken cancellationToken)
        {
            string url = XKCD_URL + await RandomComicNumber() + XKCD_URL_END;

            return await _apidata.Get(url);
        }

        private async Task<int> RandomComicNumber()
        {
            if (UnsavedComicList == null)
            {
                var comic = await _apidata.Get(XKCD_MOST_RECENT_URL);
                var mostRecentComic = comic.Num;

                UnsavedComicList = new List<int>();
                for (int i = 0; i <= mostRecentComic; i++)
                {
                    if (!_dbdata.SavedComicList.Contains(i))
                    {
                        UnsavedComicList.Add(i);
                    }
                }
            }

            var random = new Random();
 
            var randomIndex = random.Next(0, UnsavedComicList.Count);
   
            return UnsavedComicList[randomIndex];
        }
    }

}