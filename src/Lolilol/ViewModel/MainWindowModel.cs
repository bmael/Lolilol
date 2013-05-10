namespace Lolilol.ViewModel
{
    using System.Windows;

    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.ViewModel;

    /// <summary>
    /// The main window model.
    /// </summary>
    public class MainWindowModel : NotificationObject
    {
        #region .ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowModel"/> class.
        /// </summary>
        public MainWindowModel()
        {
            this.QuitClickedCommand = new DelegateCommand(this.QuitClicked);
        }

        #endregion

        #region Delegate Commands

        /// <summary>
        /// Gets the quit clicked command.
        /// </summary>
        public DelegateCommand QuitClickedCommand { get; private set; } 
 
        #endregion

        #region Commands

        /// <summary>
        /// The quit clicked.
        /// </summary>
        private void QuitClicked()
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}