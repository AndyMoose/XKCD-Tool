using Moq;
using XKCDLibrary.Commands;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Models;
using XKCDLibrary.Handlers;
using Xunit;
using System.Threading;

namespace XKCDLibrary.Tests
{
    
    public class DBDeleteComicHandlerTests
    {

        [Fact]
        public async void ReturnsSameComicPassed()
        {
            //arrange
            var comic = new Comic()
            {
                Num = 100
            };

            var dbData = new Mock<IDBDataAccess>();
            dbData.Setup(x => x.Delete(It.IsAny<Comic>())).ReturnsAsync(comic);

            var deleteCommand = new DBDeleteComicCommand(comic);
            var cancelToken = new CancellationToken();
            var deleteHandler = new DBDeleteComicHandler(dbData.Object);

            //act
            var returnComic = await deleteHandler.Handle(deleteCommand, cancelToken);

            //assert
            Assert.Equal(comic.Num, returnComic.Num);
        }
    }
}
