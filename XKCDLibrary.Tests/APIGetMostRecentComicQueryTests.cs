using Moq;
using System.Threading;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Handlers;
using XKCDLibrary.Models;
using XKCDLibrary.Queries;
using Xunit;

namespace XKCDLibrary.Tests
{
    public class APIGetMostRecentComicQueryTests
    {
        [Fact]
        public async void ReturnsMostRecentComic()
        {
            const int MAXCOMIC = 2000;

            string mostRecentUrl = "https://xkcd.com/info.0.json";

            var mostRecentComic = new ComicModel()
            {
                Num = MAXCOMIC
            };

            //arrange
            var apiData = new Mock<IAPIDataAccess>();
            apiData.Setup(x => x.Get(It.Is<string>(url => url.Equals(mostRecentUrl)))).ReturnsAsync(mostRecentComic);

            var apiComicHandler = new APIGetMostRecentComicHandler(apiData.Object);
            var query = new APIGetMostRecentComicQuery();
            var cancelToken = new CancellationToken();

            //act
            var result = await apiComicHandler.Handle(query, cancelToken);

            //assert
            Assert.Equal(MAXCOMIC, result.Num);
        }
    }
}
