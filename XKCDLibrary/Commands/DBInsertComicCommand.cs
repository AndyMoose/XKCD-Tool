using MediatR;
using XKCDLibrary.Models;

namespace XKCDLibrary.Commands
{
    public class DBInsertComicCommand : IRequest<ComicModel>
    {
        public ComicModel Comic { get; set; }
        public DBInsertComicCommand(ComicModel comic)
        {
            Comic = comic;
        }
    }
}
