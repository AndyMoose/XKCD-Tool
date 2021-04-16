using MediatR;
using XKCDLibrary.Models;

namespace XKCDLibrary.Commands
{
    public class DBDeleteComicCommand : IRequest<ComicModel>
    {
        public ComicModel Comic;

        public DBDeleteComicCommand(ComicModel comic)
        {
            Comic = comic;
        }
    }
}
