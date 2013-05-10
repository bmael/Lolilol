namespace Common.Data.Utils
{
    using System;
    using System.Data;
    using System.Linq;

    using Common.Data.Models;

    using ServiceStack.Common.Extensions;
    using ServiceStack.DataAnnotations;
    using ServiceStack.OrmLite;

    /// <summary>
    /// Static class, define database useful functions.
    /// </summary>
    public static class DbTools
    {
        /// <summary>
        /// Generate a new id for SQL insert, think about it like a auto-increment replacement.
        /// </summary>
        /// <param name="connection">
        /// The database connection.
        /// </param>
        /// <typeparam name="T">
        /// The persisted class to find a new Id.
        /// </typeparam>
        /// <returns>
        /// A new id for SQL insert.
        /// </returns>
        public static long GetNewId<T>(this IDbConnection connection) where T : IHasId, new()
        {
            var ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();
            ev.Limit(1).OrderBy("ORDER BY \"Id\" DESC");

            var ids = connection.Select(ev);

            // If there is no item in the table, avoid an exception from "ids.First()" by returning a default value
            if (ids.Count == 0)
            {
                return 1;
            }

            // Get id correctly if the given item didn't already have one
            return ids.First().Id + 1;
        }

        /// <summary>
        /// Test if an item with provided id exist
        /// </summary>
        /// <typeparam name="T">
        /// The table to test.
        /// </typeparam>
        /// <param name="connection">
        /// The connection.
        /// </param>
        /// <param name="id">
        /// The id to test
        /// </param>
        /// <returns>
        /// True if the given id exist, false otherwise.
        /// </returns>
        public static bool IdExist<T>(this IDbConnection connection, long id) where T : IHasId, new()
        {
            var ev = OrmLiteConfig.DialectProvider.ExpressionVisitor<T>();
            ev.Where("\"Id\"=" + id);

            var ids = connection.Select(ev);
            return ids.Count == 1;
        }

        /// <summary>
        /// Test if an item with the same id as the given object exist
        /// </summary>
        /// <typeparam name="T">
        /// The table to test.
        /// </typeparam>
        /// <param name="connection">
        /// The database connection.
        /// </param>
        /// <param name="obj">
        /// The object to test
        /// </param>
        /// <returns>
        /// True if the given id exist, false otherwise.
        /// </returns>
        public static bool IdExist<T>(this IDbConnection connection, T obj) where T : IHasId, new()
        {
            return IdExist<T>(connection, obj.Id);
        }

        /// <summary>
        /// Guess the table name of the given type.
        /// </summary>
        /// <param name="connection">
        /// The database connection.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The table name as a <see cref="string"/>.
        /// </returns>
        public static string GetTableName(this IDbConnection connection, Type type)
        {
            var aliasAttr = type.FirstAttribute<AliasAttribute>();

            return aliasAttr != null ? aliasAttr.Name : type.Name;
        }

        /// <summary>
        /// Alias of <see cref="GetTableName"/>, Guess the table name of the given type.
        /// </summary>
        /// <param name="connection">
        /// The database connection.
        /// </param>
        /// <typeparam name="T">
        /// The type to name check.
        /// </typeparam>
        /// <returns>
        /// The table name as a <see cref="string"/>.
        /// </returns>
        public static string GetTableName<T>(this IDbConnection connection)
        {
            var type = typeof(T);
            return GetTableName(connection, type);
        }
    }
}
