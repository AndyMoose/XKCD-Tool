using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XKCDLibrary.Commands;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Models;

namespace XKCDLibrary.Handlers
{
    public class DBInsertComicHandler : IRequestHandler<DBInsertComicCommand, Comic>
    {
     
        private readonly IDBDataAccess _DBData;
        public DBInsertComicHandler(IDBDataAccess dbdata)
        {
            _DBData = dbdata;
        }
        
        public async Task<Comic> Handle(DBInsertComicCommand request, CancellationToken cancellationToken)
        {
            if(_DBData.SavedComicList.Contains(request.Comic.Num))
            {
                MessageBox.Show("This comic has already been saved.");
                return null;
            }
            else
                return await _DBData.Insert(request.Comic);
        }
    }
}
