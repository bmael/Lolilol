namespace Control.Champion.ViewModel
{
    using System.Collections.Generic;
    using Common.Champion;

    using Data.Management;
    using Data.Management.Champion;

    using Microsoft.Practices.Prism.ViewModel;

    /// <summary>
    /// The all champions model.
    /// </summary>
    public class AllChampionsModel : NotificationObject
    {
        #region attributes

        /// <summary>
        /// The champion manager.
        /// </summary>
        private readonly IChampionManager championManager;

        /// <summary>
        /// The champions.
        /// </summary>
        private IEnumerable<IChampion> champions;

        /// <summary>
        /// The selected champion.
        /// </summary>
        private Champion selectedChampion;

        #endregion

        #region .ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="AllChampionsModel"/> class.
        /// </summary>
        public AllChampionsModel() : this(new ChampionManager(DbConnectionProvider.Instance()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AllChampionsModel"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public AllChampionsModel(IChampionManager manager)
        {
            this.championManager = manager;
            this.champions = manager.Get();
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the champions.
        /// </summary>
        public IEnumerable<IChampion> Champions
        {
            get
            {
                return this.champions;
            }
        
            set
            {
                this.champions = value;
                this.RaisePropertyChanged("Champions");
            }   
        }

        /// <summary>
        /// Gets or sets the selected champion.
        /// </summary>
        public Champion SelectedChampion
        {
            get
            {
                return this.selectedChampion;
            }
            
            set
            {
                this.selectedChampion = value;
                this.RaisePropertyChanged("SelectedChampion");
            }
        }

        #endregion
    }
}