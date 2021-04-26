using MediatR;
using XKCDLibrary.Models;

namespace XKCDLibrary.Queries
{
    public class APIGetMostRecentComicQuery : IRequest<Comic>
    {
    }
}
