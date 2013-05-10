using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    /// <summary>
    /// The database manager tests.
    /// </summary>
    [TestClass]
    public class DbManagerTest
    {
        /// <summary>
        /// Test if the manager is a Singleton.
        /// </summary>
        [TestMethod]
        public void IsSingleton()
        {
            var s1 = DBManager.SingletonManager.Instance();
            var s2 = DBManager.SingletonManager.Instance();

            Assert.AreSame(s1, s2);
        }

        /// <summary>
        /// Test if the connection is opened.
        /// </summary>
        [TestMethod]
        public void IsOpened()
        {
            var s1 = DBManager.SingletonManager.Instance().Con;
            Assert.AreEqual("LolilolDB.sdf1", s1.ConnectionString);
        }
    }
}
