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
            var shekohex_points = db.GetPlayerVotePoints("shekohex");
            var unknown_points = db.GetPlayerVotePoints("unkwon");
            Assert.AreEqual(shekohex_points, 200);
            Assert.AreEqual(unknown_points, 0);
        }

        [TestMethod]
        public void UpdateUserVotePoints()
        {
            var db = new XtremeVoteHelper.Database("votes.db");
            var p = 300;
            db.UpdatePlayerVotePoints("shekohex", p);
            var shekohex_points = db.GetPlayerVotePoints("shekohex");
            Assert.AreEqual(shekohex_points, p);
            db.UpdatePlayerVotePoints("shekohex", 200);

        }

    }
}
