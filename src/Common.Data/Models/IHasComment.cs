// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHasComment.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   Defines the IHasComment type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Data.Models
{
    /// <summary>
    /// The HasNote interface.
    /// </summary>
    public interface IHasComment
    {
        /// <summary>
        /// Gets or sets the comment.
        /// </summary>
        string Comment { get; set; }
    }
}

