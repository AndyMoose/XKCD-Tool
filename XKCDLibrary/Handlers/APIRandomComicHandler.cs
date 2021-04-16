using System;
using System.Threading.Tasks;
using XKCDLibrary.Queries;
using XKCDLibrary.Models;
using MediatR;
using System.Threading;
using XKCDLibrary.DataAccess;

namespace XKCDLibrary.Handlers
{
    public class APIRandomComicHandler : IRequestHandler<APIRandomComicQuery, ComicModel>
    {
        private readonly APIDataAccess _apidata;
        private readonly DBDataAccess _dbdata;

        public const int MOST_RECENT_COMIC = 2449;
        public const string XKCD_URL = "https://xkcd.com/";
        public const string XKCD_URL_END = "/info.0.json";

        public APIRandomComicHandler(APIDataAccess apidata, DBDataAccess dbdata)
        {
            _apidata = apidata;
            _dbdata = dbdata;
        }
        public async Task<ComicModel> Handle(APIRandomComicQuery request, CancellationToken cancellationToken)
        {
            string url = XKCD_URL + await RandomComicNumber() + XKCD_URL_END;

            return await _apidata.Get(url);
        }
        private Task<int> RandomComicNumber()
        {
            int counter = 0;
            int comicNumber;

            do
            {
                var random = new Random();
                comicNumber = random.Next(1, MOST_RECENT_COMIC + 1);
                counter++;

            } while (_dbdata.Nums.Contains(comicNumber) && counter < MOST_RECENT_COMIC);

            return Task.FromResult(comicNumber);
        }
    }

}