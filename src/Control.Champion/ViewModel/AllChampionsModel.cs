namespace Control.Champion.ViewModel
{
    using System.Collections.Generic;
    using Common.Champion;

    using Data.Management;
    using Data.Management.Champion;

    using Microsoft.Practices.Prism.Commands;
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

        /// <summary>
        /// The open champion details.
        /// </summary>
        private bool openChampionDetails;

        #endregion

        #region .ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="AllChampionsModel"/> class.
        /// </summary>
        public AllChampionsModel() 
            : this(new ChampionManager(DbConnectionProvider.Instance()))
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

            this.OpenChampionDetails = false;

            this.ChampionClickedCommand = new DelegateCommand(this.ChampionClicked);
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

        /// <summary>
        /// Gets or sets a value indicating whether open champion details.
        /// </summary>
        public bool OpenChampionDetails
        {
            get
            {
                return this.openChampionDetails;
            }
            
            set
            {
                this.openChampionDetails = value;
                this.RaisePropertyChanged("OpenChampionDetails");
            }
        }

        #endregion

        #region Delegate Commands

        /// <summary>
        /// Gets the champion clicked command.
        /// </summary>
        public DelegateCommand ChampionClickedCommand { get; private set; }

        #endregion

        #region Commands

        /// <summary>
        /// The champion clicked.
        /// </summary>
        private void ChampionClicked()
        {
            this.OpenChampionDetails = true;
        }

        #endregion
    }
}