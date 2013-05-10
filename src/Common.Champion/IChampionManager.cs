namespace Common.Champion
{
    using Common.Data.Managers;

    /// <summary>
    /// The ChampionManager interface.
    /// </summary>
    public interface IChampionManager : IGetManager<IChampion>, ICrudManager<IChampion>, ISearchManager<IChampion>
    {
    }
}