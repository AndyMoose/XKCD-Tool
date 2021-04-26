using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Models;
using XKCDLibrary.Queries;

namespace XKCDLibrary.Handlers
{
    public class DBGetAllSavedComicsHandler : IRequestHandler<DBGetAllSavedComicsQuery, IList<Comic>>
    {
        private readonly IDBDataAccess _data;
        public DBGetAllSavedComicsHandler(IDBDataAccess data)
        {
            _data = data;
        }
        public async Task<IList<Comic>> Handle(DBGetAllSavedComicsQuery request, CancellationToken cancellationToken)
        {
            return await _data.GetListofSavedComics();
        }
    }
}
