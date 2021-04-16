﻿using MediatR;
using XKCDLibrary.Models;

namespace XKCDLibrary.Commands
{
    public class DBInsertComicCommand : IRequest<ComicModel>
    {
        public DBInsertComicCommand()
        {

        }
    }
}
