// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICrudManager.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   The CrudManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Data.Managers
{
    using Common.Data.Models;

    /// <summary>
    /// The CrudManager interface.
    /// </summary>
    /// <typeparam name="T">
    /// The type to manage
    /// </typeparam>
    public interface ICrudManager<T> : IGenericManager<T>
        where T : IHasId
    {
        /// <summary>
        /// Insert the given item in the database.
        /// </summary>
        /// <param name="obj">
        /// The item.
        /// </param>
        /// <returns>
        /// The T.
        /// </returns>
        T Create(T obj);

        /// <summary>
        /// Update the given item in the database.
        /// </summary>
        /// <param name="obj">
        /// The item.
        /// </param>
        void Update(T obj);

        /// <summary>
        /// Remove the item with the given id from the database.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        void Remove(long id);

        /// <summary>
        /// Remove the given item from the database.
        /// </summary>
        /// <param name="obj">
        /// The id.
        /// </param>
        void Remove(T obj);
    }
}