using Moq;
using System.Threading;
using XKCDLibrary.Commands;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Handlers;
using XKCDLibrary.Models;
using Xunit;

namespace XKCDLibrary.Tests
{
    public class DBInsertComicHandlerTests
    {
        [Fact]
        public async void ReturnsSameComicPassed()
        {
            //arrange
            var comic = new ComicModel()
            {
                Num = 100
            };

            var dbData = new Mock<IDBDataAccess>();
            dbData.Setup(x => x.Insert(It.IsAny<ComicModel>())).ReturnsAsync(comic);

            var insertCommand = new DBInsertComicCommand(comic);
            var cancelToken = new CancellationToken();
            var insertHandler = new DBInsertComicHandler(dbData.Object);

            //act
            var returnComic = await insertHandler.Handle(insertCommand, cancelToken);

            //assert
            Assert.Equal(comic.Num, returnComic.Num);
        }
    }
}
