using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBManager.SingletonManager;

namespace DBManager
{
    [TestClass]
    public class DBManagerTest
    {
        [TestMethod]
        public void isSingleton()
        {
            SingletonManager s1 = SingletonManager.Instance();
            SingletonManager s2 = SingletonManager.Instance();

            Assert.AreSame(s1, s2);
        }
    }
}
