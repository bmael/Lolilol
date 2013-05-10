// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPerson.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   Defines the IPerson type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Data.Models
{
    using System;

    /// <summary>
    /// The Person interface.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the middle name.
        /// </summary>
        string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        string LastName { get; set; }

        /// <summary>
        /// Gets or sets the initials.
        /// </summary>
        string Initials { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Civility { get; set; }

        /// <summary>
        /// Gets or sets the birth day.
        /// </summary>
        DateTime Birthdate { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the first personal phone personal.
        /// </summary>
        string PhonePerso1 { get; set; }

        /// <summary>
        /// Gets or sets the second personal phone 2.
        /// </summary>
        string PhonePerso2 { get; set; }
    }
}

