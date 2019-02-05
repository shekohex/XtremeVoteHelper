using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace XtremeVoteDatabaseTest
{
    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void Connection()
        {
            var db = new XtremeVoteHelper.Database("votes.db");
            Assert.IsNotNull(db);
        }

        [TestMethod]
        public void CheckUserVotePoints()
        {
            var db = new XtremeVoteHelper.Database("votes.db");
            var sehekohex_points = db.GetPlayerVotePoints("shekohex");
            var unknown_points = db.GetPlayerVotePoints("unkwon");
            Assert.AreEqual(sehekohex_points, 100);
            Assert.AreEqual(unknown_points, 0);
        }
    }
}
