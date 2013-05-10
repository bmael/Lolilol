namespace Data.Management.Champion
{
    using System.Data;

    using Common.Champion;
    using Common.Data.Utils;

    /// <summary>
    /// The champion manager.
    /// </summary>
    public class ChampionManager : DbManagerBase<IChampion, Champion>, IChampionManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChampionManager"/> class.
        /// </summary>
        /// <param name="db">
        /// An <see cref="IDbConnection"/>.
        /// </param>
        public ChampionManager(IDbConnection db)
            : base(db)
        {
        }
    }
}