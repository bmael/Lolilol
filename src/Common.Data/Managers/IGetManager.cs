// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetManager.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   Defines the IGetManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Data.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Common.Data.Models;

    /// <summary>
    /// The GetManager interface.
    /// </summary>
    /// <typeparam name="T">
    /// The type to manage 
    /// </typeparam>
    public interface IGetManager<T> : IGenericManager<T> where T : IHasId
    {
        /// <summary>
        /// Get an item from the database with the given id
        /// </summary>
        /// <param name="id">
        /// The id to get.
        /// </param>
        /// <returns>
        /// An object with type T.
        /// </returns>
        T Get(long id);

        /// <summary>
        /// Get all items from database
        /// </summary>
        /// <returns>
        /// An items list.
        /// </returns>
        IEnumerable<T> Get();

        /// <summary>
        /// Get all items from database ordered by the given column.
        /// </summary>
        /// <param name="orderKey">
        /// The order key.
        /// </param>
        /// <typeparam name="TKey">
        /// An lambda expression containing the ordering column
        /// </typeparam>
        /// <returns>
        /// An items list.
        /// </returns>
        IEnumerable<T> Get<TKey>(Expression<Func<T, TKey>> orderKey);

        /// <summary>
        /// Get 10 items from database.
        /// </summary>
        /// <param name="page">
        /// The items page.
        /// </param>
        /// <returns>
        /// An items list.
        /// </returns>
        IEnumerable<T> Get(int page);

        /// <summary>
        /// Get 10 items from database ordered by the given column.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="orderKey">
        /// The order key.
        /// </param>
        /// <typeparam name="TKey">
        /// An lambda expression containing the ordering column
        /// </typeparam>
        /// <returns>
        /// An items list.
        /// </returns>
        IEnumerable<T> Get<TKey>(int page, Expression<Func<T, TKey>> orderKey);

        /// <summary>
        /// Get n items from database.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="span">
        /// The number of items to get.
        /// </param>
        /// <returns>
        /// An items list.
        /// </returns>
        IEnumerable<T> Get(int page, int span);

        /// <summary>
        /// Get n items from database ordered by the given column.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="span">
        /// The number of items to get.
        /// </param>
        /// <param name="orderKey">
        /// The order key.
        /// </param>
        /// <typeparam name="TKey">
        /// An lambda expression containing the ordering column
        /// </typeparam>
        /// <returns>
        /// An items list.
        /// </returns>
        IEnumerable<T> Get<TKey>(int page, int span, Expression<Func<T, TKey>> orderKey);
    }
}
