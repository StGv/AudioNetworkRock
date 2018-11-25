using AudioNetworkRock.Models;
using AudioNetworkRock.Repository;
using AudioNetworkRock.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace AudioNetworkRock.Tests
{
    [TestClass]
    public class RockServiceTest
    {
        RockService _target;
        Mock<IRepository<Track>> _tracks;
        Mock<IRepository<Composer>> _composers;

        [TestInitialize]
        public void SetUp()
        {
            _tracks = new Mock<IRepository<Track>>();
            _composers = new Mock<IRepository<Composer>>();
            _target = new RockService(_tracks.Object, _composers.Object);
        }

        [TestMethod]
        public void TestThatAllTracksOfGenreROCKAreReturnedInResposne()
        {
            var mockTracks = new List<Track>()
            {
                new Track() { ID = 1, Genre="rock", ComposerId = 1, Title="TestTitle" },
                new Track() { ID = 2, Genre="electronic", ComposerId = 1, Title="TestTitle2" },
                new Track() { ID = 3, Genre="rock", ComposerId = 1, Title="TestTitle3" },
            };
            var mockComposers = new List<Composer>();

            //// Arrange
            _tracks.Setup(x => x.GetAll()).Returns(mockTracks);
            _composers.Setup(x => x.GetAll()).Returns(mockComposers);

            //// Act
            var actual = _target.GetTracksWithComposernames(Genre.Rock);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is IEnumerable<TrackWithComposerName>);
            Assert.IsTrue(actual.Count() == 2);
            Assert.IsTrue((actual as List<TrackWithComposerName>)[0].Id == 1);
            Assert.IsTrue((actual as List<TrackWithComposerName>)[1].Id == 3);
        }
        [TestMethod]
        public void TestThatTracksAreSortedAlphabeticallyInResposne()
        {
            var mockTracks = new List<Track>()
            {
                new Track() { ID = 1, Genre="rock", ComposerId = 1, Title="c" },
                new Track() { ID = 2, Genre="rock", ComposerId = 1, Title="b" },
                new Track() { ID = 3, Genre="rock", ComposerId = 1, Title="a" },
            };
            var mockComposers = new List<Composer>();

            //// Arrange
            _tracks.Setup(x => x.GetAll()).Returns(mockTracks);
            _composers.Setup(x => x.GetAll()).Returns(mockComposers);

            //// Act
            var actual = _target.GetTracksWithComposernames(Genre.Rock);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue((actual as List<TrackWithComposerName>)[0].Title == "a");
            Assert.IsTrue((actual as List<TrackWithComposerName>)[1].Title == "b");
            Assert.IsTrue((actual as List<TrackWithComposerName>)[2].Title == "c");
        }

        [TestMethod]
        public void TestThatTracksInResposeContainComposerName()
        {
            var mockTracks = new List<Track>()
            {
                new Track() { ID = 1, Genre="rock", ComposerId = 1, Title="Test Title 1" },
                new Track() { ID = 2, Genre="rock", ComposerId = 2, Title="Test Title 2" },
                new Track() { ID = 3, Genre="rock", ComposerId = 3, Title="Test Title 3" },
            };
            var mockComposers = new List<Composer>()
            {
                new Composer(){ ID = 1, FirstName = "Jon", LastName = "Doe", Title = "Mr", Award = string.Empty},
                new Composer(){ ID = 2, FirstName = "Jon", LastName = "Smith", Title = "Mr", Award = string.Empty},
                new Composer(){ ID = 3, FirstName = "Jane", LastName = "Duffy", Title = "Ms", Award = string.Empty},
            };

            //// Arrange
            _tracks.Setup(x => x.GetAll()).Returns(mockTracks);
            _composers.Setup(x => x.GetAll()).Returns(mockComposers);

            //// Act
            var actual = _target.GetTracksWithComposernames(Genre.Rock);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue((actual as List<TrackWithComposerName>)[0].ComposerName == "Jon Doe");
            Assert.IsTrue((actual as List<TrackWithComposerName>)[1].ComposerName == "Jon Smith");
            Assert.IsTrue((actual as List<TrackWithComposerName>)[2].ComposerName == "Jane Duffy");
        }

        [TestMethod]
        public void TestThatTracksAreReturnedWhenNoMatchingComposerExists()
        {
            var mockTracks = new List<Track>()
            {
                new Track() { ID = 1, Genre="rock", ComposerId = 1, Title="Test Title 1" },
                new Track() { ID = 2, Genre="rock", ComposerId = 1, Title="Test Title 2" },
                new Track() { ID = 3, Genre="rock", ComposerId = 2, Title="Test Title 3" },
            };
            var mockComposers = new List<Composer>()
            {
                new Composer(){ ID = 3, FirstName = "Jon", LastName = "Doe", Title = "Mr", Award = string.Empty},
                new Composer(){ ID = 4, FirstName = "Jon", LastName = "Smith", Title = "Mr", Award = string.Empty},
                new Composer(){ ID = 5, FirstName = "Jane", LastName = "Duffy", Title = "Ms", Award = string.Empty},
            };

            //// Arrange
            _tracks.Setup(x => x.GetAll()).Returns(mockTracks);
            _composers.Setup(x => x.GetAll()).Returns(mockComposers);

            //// Act
            var actual = _target.GetTracksWithComposernames(Genre.Rock);

            // Assert
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is IEnumerable<TrackWithComposerName>);
            Assert.IsTrue(actual.Count() == 3);
            Assert.IsTrue((actual as List<TrackWithComposerName>)[0].ComposerName == string.Empty);
            Assert.IsTrue((actual as List<TrackWithComposerName>)[1].ComposerName == string.Empty);
            Assert.IsTrue((actual as List<TrackWithComposerName>)[2].ComposerName == string.Empty);
        }
    }
}
