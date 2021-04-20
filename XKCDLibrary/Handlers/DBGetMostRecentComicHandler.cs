using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XKCDLibrary.Queries;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Models;

namespace XKCDLibrary.Handlers
{
    public class APIGetMostRecentComicHandler : IRequestHandler<APIGetMostRecentComicQuery, ComicModel>
    {
        private const string XKCD_MOST_RECENT_URL = "https://xkcd.com/info.0.json";
        private readonly IAPIDataAccess _APIData;
        public APIGetMostRecentComicHandler(IAPIDataAccess apidata)
        {
            _APIData = apidata;
        }
        
        public async Task<ComicModel> Handle(APIGetMostRecentComicQuery request, CancellationToken cancellationToken)
        {
            return await _APIData.Get(XKCD_MOST_RECENT_URL);
        }
    }
}
