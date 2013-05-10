namespace Data.Management.Champion
{
    using Common.Champion;

    /// <summary>
    /// The champion.
    /// </summary>
    public class Champion : IChampion
    {
        #region IHasId

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public long Id { get; set; }

        #endregion

        #region IHero

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the lore.
        /// </summary>
        public string Lore { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        public string Tags { get; set; }

        #endregion
    }
}