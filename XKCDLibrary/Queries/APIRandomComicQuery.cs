using MediatR;
using XKCDLibrary.Models;

namespace XKCDLibrary.Queries
{
    public class APIRandomComicQuery : IRequest<ComicModel>
    {
        public APIRandomComicQuery()
        {
        }
    }
}
