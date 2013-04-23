using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DBManager
{
    class SingletonManager
    {
        private static SingletonManager _instance;

        private String stringConnection
        {
            get; set;
        }

        private SqlConnection con
        {
            get; set;
        }

        protected SingletonManager()
        {
            using (con = new SqlConnection(stringConnection) )
            {

            }
        }

        public static SingletonManager Instance()
        {
             if (_instance == null) _instance = new SingletonManager();
             return _instance;
        }
    
    }
}
