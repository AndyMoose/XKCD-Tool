using MediatR;
using XKCDLibrary.Models;

namespace XKCDLibrary.Commands
{
    public class DBDeleteComicCommand : IRequest<Comic>
    {
        public Comic Comic;
        public DBDeleteComicCommand(Comic comic)
        {
            Comic = comic;
        }
    }
}
