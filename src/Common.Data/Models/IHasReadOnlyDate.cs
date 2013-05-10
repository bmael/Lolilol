// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasReadOnlyDate.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   Defines the IHasReadOnlyDate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Data.Models
{
    using System;

    /// <summary>
    /// The IHasReadOnlyDate interface, add DateCreated and DateModified fields.
    /// </summary>
    public interface IHasReadOnlyDate
    {
        /// <summary>
        /// Gets the creation date.
        /// </summary>
        DateTime DateCreated { get; }

        /// <summary>
        /// Gets the date of modification.
        /// </summary>
        DateTime DateModified { get; }
    }
}