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
        private ComicModel _comic;
        private ComicModel _mostRecentComic;
        private Mock<IAPIDataAccess> _apiData;
        private Mock<IDBDataAccess> _dbData;
        private List<int> _shortList;
        private List<int> _fullList;
        private const int MAXCOMIC = 2000;

        public APIRandomComicHandlerTests()
        {
            _comic = new ComicModel()
            {
                Num = 100
            };

            _mostRecentComic = new ComicModel()
            {
                Num = MAXCOMIC
            };

            _shortList = new List<int>
            {
                99, 101
            };

            _fullList = new List<int>();
            for (int i = 1; i < MAXCOMIC; i++)
            {
                _fullList.Add(i);
            }
        
        }

        [Fact]
        public async void HandlerReturnsComic()
        {
            //arrange
            _apiData = new Mock<IAPIDataAccess>();
            _apiData.Setup(x => x.Get(It.IsNotNull<string>())).ReturnsAsync(_comic);

            _dbData = new Mock<IDBDataAccess>();
            _dbData.Setup(x => x.SavedComicList).Returns(_shortList);

            var apiComicHandler = new APIRandomComicHandler(_apiData.Object, _dbData.Object);
            var randomComicQuery = new APIRandomComicQuery();
            var cancelToken = new CancellationToken();

            //act
            ComicModel comic = await apiComicHandler.Handle(randomComicQuery, cancelToken);

            //assert
            Assert.NotNull(comic);
        }

        [Fact]
        public async void HandlerOnlyUsesUnsavedComics()
        {
            _apiData = new Mock<IAPIDataAccess>();
            _apiData.Setup(x => x.Get(It.IsNotNull<string>())).ReturnsAsync(_mostRecentComic);

            _dbData = new Mock<IDBDataAccess>();
            _dbData.Setup(x => x.SavedComicList).Returns(_fullList);

            var apiComicHandler = new APIRandomComicHandler(_apiData.Object, _dbData.Object);
            var randomComicQuery = new APIRandomComicQuery();
            var cancelToken = new CancellationToken();

            //act
            ComicModel comic = await apiComicHandler.Handle(randomComicQuery, cancelToken);

            //assert
            Assert.Equal(comic.Num, MAXCOMIC);
        }
    }
}
