namespace Common.Data
{
    using System;

    /// <summary>
    /// The Factory interface.
    /// </summary>
    /// <typeparam name="T">
    /// The returned type.
    /// </typeparam>
    public interface IFactory<out T>
    {
        /// <summary>
        /// Create a new instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="T"/>.
        /// </returns>
        T Create();

        /// <summary>
        /// Create a new instance of <typeparamref name="T"/> with the given <paramref name="properties"/>.
        /// </summary>
        /// <param name="properties">
        /// The new object properties.
        /// </param>
        /// <returns>
        /// A new instance of <see cref="T"/>.
        /// </returns>
        T Create(Action<T> properties);
    }
}