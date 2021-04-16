using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XKCDLibrary.Commands;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Models;

namespace XKCDLibrary.Handlers
{
    class DBInsertComicHandler : IRequestHandler<DBInsertComicCommand, ComicModel>
    {
     
        private readonly DBDataAccess _DBData;
        private readonly APIDataAccess _APIData;
        public DBInsertComicHandler(DBDataAccess dbdata, APIDataAccess apidata)
        {
            _DBData = dbdata;
            _APIData = apidata;
        }
        
        public async Task<ComicModel> Handle(DBInsertComicCommand request, CancellationToken cancellationToken)
        {
            var xkcd = _APIData.Xkcd;
            return await _DBData.Insert(xkcd);
        }
    }
}
