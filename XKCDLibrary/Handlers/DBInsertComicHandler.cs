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
     
        private readonly IDBDataAccess _DBData;
        public DBInsertComicHandler(IDBDataAccess dbdata)
        {
            _DBData = dbdata;
        }
        
        public async Task<ComicModel> Handle(DBInsertComicCommand request, CancellationToken cancellationToken)
        {
            return await _DBData.Insert(request.Comic);
        }
    }
}
