namespace Tools.Collections.Generic
{
    using System.Collections.Generic;

    /// <summary>
    /// The headered list.
    /// </summary>
    public class HeaderedList<T> : List<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderedList{T}"/> class.
        /// </summary>
        /// <param name="header">
        /// The header.
        /// </param>
        public HeaderedList(string header)
        {
            this.Header = header;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderedList{T}"/> class.
        /// </summary>
        /// <param name="header">
        /// The header.
        /// </param>
        /// <param name="items">
        /// The items.
        /// </param>
        public HeaderedList(string header, IEnumerable<T> items)
        {
            this.AddRange(items);
            this.Header = header;
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        public string Header { get; set; }
    }
}