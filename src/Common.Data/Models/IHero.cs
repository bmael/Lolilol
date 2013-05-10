namespace Common.Data.Models
{
    /// <summary>
    /// The Hero interface.
    /// </summary>
    public interface IHero
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Gets or sets the lore.
        /// </summary>
        string Lore { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        string Tags { get; set; }
    }
}