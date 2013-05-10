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
        /// Initializes a new instance of the <see cref="SingletonManager"/> class.
        /// </summary>
        protected SingletonManager()
        {
            this.stringConnection = "database=LolilolDB.sdf1";
            using (this.Con = new SqlConnection(this.stringConnection))
            {
                this.Con.Open();
            }
        }

        /// <summary>
        /// Gets or sets the con.
        /// </summary>
        public SqlConnection Con { get; set; }

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
