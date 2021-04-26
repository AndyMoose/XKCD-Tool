using Moq;
using System.Collections.Generic;
using System.Threading;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Handlers;
using XKCDLibrary.Models;
using XKCDLibrary.Queries;
using Xunit;

namespace XKCDLibrary.Tests
{
    public class DBGetAllSavedComicsHandlerTests
    {
        [Fact]
        public async void GetsAllComics()
        {
            //arrange
            var comiclist = new List<Comic>();
            for (int i = 1; i <= 10; i++)
            {
                comiclist.Add(
                    new Comic()
                    {
                        Num = i
                    });
            }
            
            var dbData = new Mock<IDBDataAccess>();
            dbData.Setup(x => x.GetListofSavedComics()).ReturnsAsync(comiclist);

            var handler = new DBGetAllSavedComicsHandler(dbData.Object);
            var query = new DBGetAllSavedComicsQuery();
            var cancelToken = new CancellationToken();

            //act
            var result = await handler.Handle(query, cancelToken);

            //assert
            for(int i = 0; i < 10; i++)
            {
                Assert.Equal(result[i].Num, comiclist[i].Num);
            }
        }
    }
}
