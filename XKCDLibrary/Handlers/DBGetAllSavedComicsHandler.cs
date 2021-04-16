using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Models;
using XKCDLibrary.Queries;

namespace XKCDLibrary.Handlers
{
    public class DBGetAllSavedComicsHandler : IRequestHandler<DBGetAllSavedComicsQuery, IList<ComicModel>>
    {
        private readonly DBDataAccess _data;
        public DBGetAllSavedComicsHandler(DBDataAccess data)
        {
            _data = data;
        }
        public async Task<IList<ComicModel>> Handle(DBGetAllSavedComicsQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetList();
        }
    }
}
