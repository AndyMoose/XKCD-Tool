using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XKCDLibrary.Commands;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Models;

namespace XKCDLibrary.Handlers
{
    public class DBDeleteComicHandler : IRequestHandler<DBDeleteComicCommand, Comic>
    {
        private readonly IDBDataAccess _data;

        public DBDeleteComicHandler (IDBDataAccess data)
        {
            _data = data;
        }

        public async Task<Comic> Handle(DBDeleteComicCommand request, CancellationToken cancellationToken)
        {
            return await _data.Delete(request.Comic);
        }
    }
}
