using MediatR;
using System.Threading;
using System.Threading.Tasks;
using XKCDLibrary.Commands;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Models;

namespace XKCDLibrary.Handlers
{
    class DBDeleteComicHandler : IRequestHandler<DBDeleteComicCommand, ComicModel>
    {
        private readonly DBDataAccess _data;

        public DBDeleteComicHandler (DBDataAccess data)
        {
            _data = data;
        }

        public async Task<ComicModel> Handle(DBDeleteComicCommand request, CancellationToken cancellationToken)
        {
            return await _data.Delete(request.Comic);
        }
    }
}
