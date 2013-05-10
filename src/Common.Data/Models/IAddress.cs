// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAddress.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   The Address interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Data.Models
{
    /// <summary>
    /// The Address interface.
    /// </summary>
    public interface IAddress
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        string Address3 { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        string Zip { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        string State { get; set; }
    }
}