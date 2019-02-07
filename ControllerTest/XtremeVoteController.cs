using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllerTest
{
    [TestClass]
    public class XtremeVoteController
    {
        private readonly int servicePort = 8080;
        struct Player
        {
           public int points;
           public string username;
        }
        [TestMethod]
        public void SetPlayerPoints()
        {
            var p = new Player()
            {
                username = "shekohex",
                points = 100,
            };

            var controller = new XtremeVoteHelper.Controller(servicePort);
            var result = controller.SetPlayerPoints(p.username, p.points).Result;
            Assert.AreEqual(result, p.points);
        }

        [TestMethod]
        public void GetPlayerPoints()
        {
            var p = new Player()
            {
                username = "shekohex",
                points = 10,
            };

            var controller = new XtremeVoteHelper.Controller(servicePort);
            controller.SetPlayerPoints(p.username, p.points).Wait();
            var result = controller.GetPlayerPoints(p.username).Result;
            Assert.AreEqual(result, p.points);
        }
    }
}
