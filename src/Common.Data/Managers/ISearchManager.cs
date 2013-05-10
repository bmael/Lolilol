// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearchManager.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   Defines the ISearchManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Data.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Common.Data.Models;

    /// <summary>
    /// The Searchable interface.
    /// </summary>
    /// <typeparam name="T">
    /// The type to search.
    /// </typeparam>
    public interface ISearchManager<T> where T : IHasId
    {
        /// <summary>
        /// Search an item in the database.
        /// </summary>
        /// <param name="predictate">
        /// The search predictate.
        /// </param>
        /// <returns>
        /// A list of matches.
        /// </returns>
        IEnumerable<T> Search(Expression<Func<T, bool>> predictate);
    }
}
