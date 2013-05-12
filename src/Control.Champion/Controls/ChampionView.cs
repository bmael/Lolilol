namespace Control.Champion.Controls
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using Common.Champion;

    using Data.Management;
    using Data.Management.Champion;

    /// <summary>
    /// The champion view model.
    /// </summary>
    [TemplatePart(Name = "PART_ChampionName", Type = typeof(TextBlock))]
    [TemplatePart(Name = "PART_PI", Type = typeof(Label))]
    [TemplatePart(Name = "PART_RI", Type = typeof(Label))]
    [TemplatePart(Name = "PART_Description", Type = typeof(TextBlock))]
    public class ChampionView : Control
    {
        #region Dependency properties

        /// <summary>
        /// The test name property.
        /// </summary>
        public static readonly DependencyProperty ChampionNameProperty = DependencyProperty.Register(
            "ChampionName", typeof(string), typeof(ChampionView), new PropertyMetadata(string.Empty));

        #endregion

        #region routedEvent

        /// <summary>
        /// The champion name changed event.
        /// </summary>
        public static readonly RoutedEvent ChampionNameChangedEvent = EventManager.RegisterRoutedEvent(
            "ChampionNameChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChampionView));

        #endregion

        #region attribute

        /// <summary>
        /// The manager.
        /// </summary>
        private readonly IChampionManager manager;

        #endregion

        #region Template part

        /// <summary>
        /// The champion name.
        /// </summary>
        private TextBlock championName;

        /// <summary>
        /// The pi.
        /// </summary>
        private Label pi;

        /// <summary>
        /// The ri.
        /// </summary>
        private Label ri;

        /// <summary>
        /// The description.
        /// </summary>
        private TextBlock description;

        #endregion

        #region .ctors

        /// <summary>
        /// Initializes static members of the <see cref="ChampionView"/> class.
        /// </summary>
        static ChampionView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChampionView), new FrameworkPropertyMetadata(typeof(ChampionView)));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChampionView"/> class.
        /// </summary>
        public ChampionView() 
            : this(new ChampionManager(DbConnectionProvider.Instance()))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChampionView"/> class.
        /// </summary>
        /// <param name="manager">
        /// The manager.
        /// </param>
        public ChampionView(IChampionManager manager)
        {
            this.manager = manager;
        }

        #endregion

        #region events

        /// <summary>
        /// Occurs when [value changed].
        /// </summary>
        public event RoutedEventHandler ChampionNameChanged
        {
            add
            {
                this.AddHandler(ChampionNameChangedEvent, value);
            }

            remove
            {
                this.RemoveHandler(ChampionNameChangedEvent, value);
            }
        }

        #endregion

        #region properties
        /// <summary>
        /// Gets or sets the champion name.
        /// </summary>
        public string ChampionName
        {
            get
            {
                return (string)this.GetValue(ChampionNameProperty);
            }

            set
            {
                this.SetValue(ChampionNameProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the current champion.
        /// </summary>
        public IChampion CurrentChampion { get; set; }

        /// <summary>
        /// Gets or sets the pi.
        /// </summary>
        public string Pi { 
            get
            {
                return (string)this.pi.Content;
            }
            
            set
            {
                this.pi.Content = value;
            }
        }

        /// <summary>
        /// Gets or sets the ri.
        /// </summary>
        public string Ri
        {
            get
            {
                return (string)this.ri.Content;
            }

            set
            {
                this.ri.Content = value;
            }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description.Text;
            }

            set
            {
                this.description.Text = value;
            }
        }

        #endregion
       

        #region override methods

        /// <summary>
        /// The on apply template.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.championName = this.GetTemplateChild("PART_ChampionName") as TextBlock;
            this.ri = this.GetTemplateChild("PART_RI") as Label;
            this.pi = this.GetTemplateChild("PART_PI") as Label;
            this.description = this.GetTemplateChild("PART_Description") as TextBlock;
        }

        #endregion

        #region methods

        /// <summary>
        /// The coerce value.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        private static object CoerceValue(DependencyObject d, object value)
        {
            var championView = d as ChampionView;
            return value;
        }

        #endregion

        #region dependency properties methods

        /// <summary>
        /// The champion name property changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ChampionNamePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var championView = d as ChampionView;
            if (championView == null)
            {
                return;
            }

            championView.ChampionName = (string)e.NewValue;

            var championsRes = this.manager.Get(champion => champion.Name == championView.ChampionName);
            championView.CurrentChampion = championsRes.First();

            championView.RaiseChampionNameChangedEvent();
        }

        #endregion

        #region raise events

        /// <summary>
        /// The raise champion name c hanged event.
        /// </summary>
        private void RaiseChampionNameChangedEvent()
        {
            this.RaiseEvent(new RoutedEventArgs(ChampionNameChangedEvent));
        }

        #endregion

    }
}