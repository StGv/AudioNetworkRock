using AudioNetworkRock.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AudioNetworkRock.Tests
{
    [TestClass]
    public class GenreExtentionTest
    {

        [TestMethod]
        public void TestIfConverToStringWorks()
        {
            Assert.IsTrue("rock".Equals(Genre.Rock.toString()));
            Assert.IsTrue(Genre.Rock.toString().Equals("rock"));
            Assert.IsTrue("rock" == Genre.Rock.toString());
        }

        [TestMethod]
        public void TestIfGenreConverterFromStringToGenreWorks()
        {
            Assert.IsTrue(GenreConverter.ConvertFrom("rock").Equals(Genre.Rock));
            Assert.IsTrue(GenreConverter.ConvertFrom("Rock").Equals(Genre.Rock));

        }
    }
}
