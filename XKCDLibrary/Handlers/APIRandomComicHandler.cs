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
    public class APIRandomComicHandler : IRequestHandler<APIRandomComicQuery, Comic>
    {
        private readonly IAPIDataAccess _apidata;
        private readonly IDBDataAccess _dbdata;

        public APIRandomComicHandler(IAPIDataAccess apidata, IDBDataAccess dbdata)
        {
            _apidata = apidata;
            _dbdata = dbdata;
        }

        public async Task<Comic> Handle(APIRandomComicQuery request, CancellationToken cancellationToken)
        {
            string url = APIDataAccess.XKCD_URL + await RandomComicNumber() + APIDataAccess.XKCD_URL_END;

            return await _apidata.Get(url);
        }

        private Task<int> RandomComicNumber()
        {
            var unsavedComicList = _dbdata.UnsavedComicList;

            var random = new Random();
 
            var randomIndex = random.Next(0, unsavedComicList.Count);

            return Task.FromResult(unsavedComicList[randomIndex]);
        }
    }
}