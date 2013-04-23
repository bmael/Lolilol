using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The database manager tests.
    /// </summary>
    [TestClass]
    public class DbManagerTest
    {
        /// <summary>
        /// Test if the manager is a Singleton.
        /// </summary>
        public void IsSingleton()
        {
            var s1 = DBManager.SingletonManager.Instance();
            var s2 = DBManager.SingletonManager.Instance();

            Assert.AreSame(s1, s2);
        }
    }
}
