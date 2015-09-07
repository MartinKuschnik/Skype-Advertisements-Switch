namespace SkypeAdvertisementsSwitch.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Windows.Input;
    using InternetExplorer.SecurityZoneManagement;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The website which is used to show advertisements inside of Skype.
        /// </summary>
        private const string SkypeAdvertisementsSite = "https://apps.skype.com";

        /// <summary>
        /// An instance of the <see cref="IInternetSecurityManager"/> which is used to control the security rules of the Internet Explorer.
        /// </summary>
        private readonly IInternetSecurityManager internetSecurityManager = new InternetSecurityManager();

        /// <summary>
        /// The command to block or resume the Skype advertisements.
        /// </summary>
        private readonly RelayCommand toggleAdvertisementsBlockingCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            toggleAdvertisementsBlockingCommand = new RelayCommand((o) => ToggleAdvertisementsBlocking(o));
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets a value indicating whether the Skype advertisements are blocked.
        /// </summary>
        /// <value>
        /// <c>true</c> if  the Skype advertisements are blocked, otherwise <c>false</c>.
        /// </value>
        public bool IsAdvertisementsBlocked
        {
            get
            {
                // this code only works if there are less then 1000 blocked sites

                IEnumString blockedSitesEnumerator;
                string[] blockedSites = new string[999];
                IntPtr blockedSitesCount = IntPtr.Zero;

                internetSecurityManager.GetZoneMappings(UrlZone.Untrusted, out blockedSitesEnumerator, 0);

                blockedSitesEnumerator.Next(blockedSites.Length, blockedSites, blockedSitesCount);

                return blockedSites.Contains(SkypeAdvertisementsSite);
            }
        }

        /// <summary>
        /// Gets the command to block or resume the Skype advertisements.
        /// </summary>
        /// <value>
        /// The command to block or resume the Skype advertisements.
        /// </value>
        public ICommand ToggleAdvertisementsBlockingCommand
        {
            get { return toggleAdvertisementsBlockingCommand; }
        }

        /// <summary>
        /// Toggles the advertisements blocking.
        /// </summary>
        /// <param name="o">Data used by the command. If the command does not require data to be passed, this object can be set to null.</param>
        private void ToggleAdvertisementsBlocking(object o)
        {
            internetSecurityManager.SetZoneMapping(UrlZone.Untrusted, SkypeAdvertisementsSite, this.IsAdvertisementsBlocked ? SetZoneMappingFlags.Delete : SetZoneMappingFlags.Create);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("IsAdvertisementsBlocked"));
            }
        }
    }
}
