using System.Threading;
using XKCDLibrary.DataAccess;
using XKCDLibrary.Handlers;
using XKCDLibrary.Models;
using XKCDLibrary.Queries;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace XKCDLibrary.Tests
{
    public class APIRandomComicHandlerTests
    {
        private Comic _comic;
        private Comic _mostRecentComic;
        private Mock<IAPIDataAccess> _apiData;
        private Mock<IDBDataAccess> _dbData;
        private List<int> _shortSavedList;
        private List<int> _fullSavedList;
        private List<int> _shortUnsavedList;
        private List<int> _fullUnsavedList;
        private const int MAXCOMIC = 2000;

        public APIRandomComicHandlerTests()
        {
            _comic = new Comic()
            {
                Num = 100
            };

            _mostRecentComic = new Comic()
            {
                Num = MAXCOMIC
            };

            _shortSavedList = new List<int>
            {
                99, 101
            };

            _shortUnsavedList = new List<int>
            {
                100
            };

            _fullSavedList = new List<int>();
            for (int i = 1; i < MAXCOMIC; i++)
            {
                _fullSavedList.Add(i);
            }

            _fullUnsavedList = new List<int>
            {
                2000
            };

        }

        [Fact]
        public async void HandlerReturnsComic()
        {
            //arrange
            _apiData = new Mock<IAPIDataAccess>();
            _apiData.Setup(x => x.Get(It.IsNotNull<string>())).ReturnsAsync(_comic);

            _dbData = new Mock<IDBDataAccess>();
            _dbData.Setup(x => x.SavedComicList).Returns(_shortSavedList);
            _dbData.Setup(x => x.UnsavedComicList).Returns(_shortUnsavedList);


            var apiComicHandler = new APIRandomComicHandler(_apiData.Object, _dbData.Object);
            var randomComicQuery = new APIRandomComicQuery();
            var cancelToken = new CancellationToken();

            //act
            Comic comic = await apiComicHandler.Handle(randomComicQuery, cancelToken);

            //assert
            Assert.NotNull(comic);
        }

        [Fact]
        public async void HandlerOnlyUsesUnsavedComics()
        {
            //arrange
            _apiData = new Mock<IAPIDataAccess>();
            _apiData.Setup(x => x.Get(It.IsNotNull<string>())).ReturnsAsync(_mostRecentComic);

            _dbData = new Mock<IDBDataAccess>();
            _dbData.Setup(x => x.SavedComicList).Returns(_fullSavedList);
            _dbData.Setup(x => x.UnsavedComicList).Returns(_fullUnsavedList);

            var apiComicHandler = new APIRandomComicHandler(_apiData.Object, _dbData.Object);
            var randomComicQuery = new APIRandomComicQuery();
            var cancelToken = new CancellationToken();

            //act
            Comic comic = await apiComicHandler.Handle(randomComicQuery, cancelToken);

            //assert
            Assert.Equal(comic.Num, MAXCOMIC);
        }
    }
}
