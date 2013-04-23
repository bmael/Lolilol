using System.Data.SqlClient;

namespace DBManager
{
    /// <summary>
    /// The singleton manager.
    /// </summary>
    public class SingletonManager
    {
        /// <summary>
        /// The _instance.
        /// </summary>
        private static SingletonManager instance;

        /// <summary>
        /// The string connection.
        /// </summary>
        private readonly string stringConnection;

        /// <summary>
        /// The con (connection to the DB).
        /// </summary>
        private SqlConnection con;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingletonManager"/> class.
        /// </summary>
        protected SingletonManager()
        {
            this.stringConnection = string.Empty;
            using (this.con = new SqlConnection(this.stringConnection))
            {
            }
        }

        /// <summary>
        /// The instance of the SingletonManager.
        /// </summary>
        /// <returns>
        /// The <see cref="SingletonManager"/>.
        /// </returns>
        public static SingletonManager Instance()
        {
            return instance ?? (instance = new SingletonManager());
        }
    }
}
