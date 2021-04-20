using Moq;
using System.Collections.Generic;
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

            var comiclist = new List<int>();
            for (int i = 1; i <= 101; i++)
            {
                if (i != 100)
                {
                    comiclist.Add(i);
                }
            }

            var dbData = new Mock<IDBDataAccess>();
            dbData.Setup(x => x.Insert(It.Is<ComicModel>(i => i.Num.Equals(100)))).ReturnsAsync(comic);
            dbData.Setup(x => x.SavedComicList).Returns(comiclist);

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
