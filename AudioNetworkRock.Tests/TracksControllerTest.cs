using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioNetworkRock.Tests
{
    [TestClass]
    class TracksControllerTest
    {
        [TestMethod]
        public void TestThatAllTracksOfGenreROCKAreReturnedInResposne()
        {
            //// Arrange
            //var repo = new FakeRepository<Widget>();
            //var controller = new TracksController(repo);
            //var expected = repo.Find(1);

            //// Act
            //var actual = controller.GetWidget(1) as OkNegotiatedContentResult<Widget>;

            //// Assert
            //Assert.IsNotNull(actual);
            //Assert.AreEqual(expected.Id, actual.Content.Id);
        }
        [TestMethod]
        public void TestThatTracksAreSortedAlphabeticallyInResposne()
        {
            //// Arrange
            //var repo = new FakeRepository<Widget>();
            //var controller = new TracksController(repo);
            //var expected = repo.Find(1);

            //// Act
            //var actual = controller.GetWidget(1) as OkNegotiatedContentResult<Widget>;

            //// Assert
            //Assert.IsNotNull(actual);
            //Assert.AreEqual(expected.Id, actual.Content.Id);
        }

        [TestMethod]
        public void TestThatTracksInResposeContainComposerName()
        {
            //// Arrange
            //var repo = new FakeRepository<Widget>();
            //var controller = new TracksController(repo);
            //var expected = repo.Find(1);

            //// Act
            //var actual = controller.GetWidget(1) as OkNegotiatedContentResult<Widget>;

            //// Assert
            //Assert.IsNotNull(actual);
            //Assert.AreEqual(expected.Id, actual.Content.Id);
        }

        [TestMethod]
        public void TestThatTracksAreReturnedWhenNoMatchingComposerExists()
        {
            //// Arrange
            //var repo = new FakeRepository<Widget>();
            //var controller = new TracksController(repo);
            //var expected = repo.Find(1);

            //// Act
            //var actual = controller.GetWidget(1) as OkNegotiatedContentResult<Widget>;

            //// Assert
            //Assert.IsNotNull(actual);
            //Assert.AreEqual(expected.Id, actual.Content.Id);
        }
    }
}
