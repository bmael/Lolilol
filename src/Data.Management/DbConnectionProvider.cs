// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DbConnectionProvider.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   Defines the DbConnectionProvider type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Data.Management
{
    using System.Data;
    using System.Data.SQLite;

    using ServiceStack.OrmLite;

    /// <summary>
    /// The database connection provider.
    /// </summary>
    public static class DbConnectionProvider
    {
        /// <summary>
        /// The sync lock.
        /// </summary>
        private static readonly object SyncLock = new object();

        /// <summary>
        /// This singleton instance.
        /// </summary>
        private static volatile IDbConnection instance;

        /// <summary>
        /// Initializes static members of the <see cref="DbConnectionProvider"/> class.
        /// </summary>
        static DbConnectionProvider()
        {
            // Init the database
            Instance(GetConnection("lolilol.sql").ConnectionString);
        }

        /// <summary>
        /// The instance.
        /// </summary>
        /// <returns>
        /// The <see cref="IDbConnection"/>.
        /// </returns>
        public static IDbConnection Instance()
        {
            return instance;
        }

        /// <summary>
        /// Singleton - Get a database connection instance
        /// </summary>
        /// <param name="connectionString">
        /// The database connection string.
        /// </param>
        /// <returns>
        /// The <see cref="IDbConnection"/>.
        /// </returns>
        public static IDbConnection Instance(string connectionString)
        {
            if (instance == null)
            {
                lock (SyncLock)
                {
                    if (instance == null)
                    {
                        return instance = new OrmLiteConnectionFactory(connectionString, true, SqliteDialect.Provider).OpenDbConnection();
                    }
                }
            }

            return instance;
        }

        /// <summary>
        /// Get a SQL connection.
        /// </summary>
        /// <param name="databasePath">
        /// The database path.
        /// </param>
        /// <returns>
        /// The <see cref="SQLiteConnectionStringBuilder"/>.
        /// </returns>
        /// <exception cref="SQLiteException">
        /// Thrown if any problem arise during the connection.
        /// </exception>
        private static SQLiteConnectionStringBuilder GetConnection(string databasePath)
        {
            try
            {
                // Build the ConnectionString to the database on demand
                var sqlcsb = new SQLiteConnectionStringBuilder
                {
                    DataSource = databasePath,
                    DefaultTimeout = 30,
#if !DEBUG
                    Password = "qecratabe8uchAfRaspatudEpHECeVu52er7Ru5a6uYey55pupep7bR9yek8cre7",
#endif
                };

                // SQLCSB.JournalMode = SQLiteJournalModeEnum.Delete;
                // SQLCSB.FailIfMissing = true;
                return sqlcsb;
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException("Impossible to get SQLite member", ex);
            }
        }
    }
}
