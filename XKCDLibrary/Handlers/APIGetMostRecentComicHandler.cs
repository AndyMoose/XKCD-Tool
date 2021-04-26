using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XKCDLibrary.Queries;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Models;

namespace XKCDLibrary.Handlers
{
    public class APIGetMostRecentComicHandler : IRequestHandler<APIGetMostRecentComicQuery, Comic>
    {
        private readonly IAPIDataAccess _APIData;
        public APIGetMostRecentComicHandler(IAPIDataAccess apidata)
        {
            _APIData = apidata;
        }
        
        public async Task<Comic> Handle(APIGetMostRecentComicQuery request, CancellationToken cancellationToken)
        {
            return await _APIData.Get(APIDataAccess.XKCD_MOST_RECENT_URL);
        }
    }
}
