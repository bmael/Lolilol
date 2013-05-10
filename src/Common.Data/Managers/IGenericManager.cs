// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGenericManager.cs" company="Dental-Moving">
//   Copyright © 2013 Dental-Moving All Rights Reserved
// </copyright>
// <summary>
//   Defines the IGenericManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Data.Managers
{
    /// <summary>
    /// The GenericManager interface.
    /// </summary>
    /// <typeparam name="T">
    /// The type to manage
    /// </typeparam>
    public interface IGenericManager<T> : IManagerBase
    {
    }
}

