// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasId.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   Defines the IHasId type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Data.Models
{
    /// <summary>
    /// The HasId interface.
    /// </summary>
    public interface IHasId
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        long Id { get; set; }
    }
}

