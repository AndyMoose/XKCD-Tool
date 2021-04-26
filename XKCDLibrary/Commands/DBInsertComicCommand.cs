using MediatR;
using XKCDLibrary.Models;

namespace XKCDLibrary.Commands
{
    public class DBInsertComicCommand : IRequest<Comic>
    {
        public Comic Comic { get; set; }
        public DBInsertComicCommand(Comic comic)
        {
            Comic = comic;
        }
    }
}
