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
            Assert.AreEqual(Genre.Rock.toString(), "rock");
            Assert.IsTrue("rock" == Genre.Rock.toString());
        }
    }
}
