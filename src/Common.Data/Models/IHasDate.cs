// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasDate.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   Defines the IHasDate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Data.Models
{
    using System;

    /// <summary>
    /// The HasDate interface, add DateCreated and DateModified fields.
    /// </summary>
    public interface IHasDate : IHasReadOnlyDate
    {
        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        new DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date modified.
        /// </summary>
        new DateTime DateModified { get; set; }
    }
}