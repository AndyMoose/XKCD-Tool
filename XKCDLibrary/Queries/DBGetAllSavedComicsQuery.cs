using MediatR;
using System.Collections.Generic;
using XKCDLibrary.Models;

namespace XKCDLibrary.Queries
{
    public class DBGetAllSavedComicsQuery : IRequest<IList<ComicModel>>
    {
        
    }
}
