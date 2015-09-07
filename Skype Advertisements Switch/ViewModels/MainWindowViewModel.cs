namespace SkypeAdvertisementsSwitch.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.InteropServices.ComTypes;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using InternetExplorer.SecurityZoneManagement;

    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private const string SkypeAdvertisementsSite = "https://apps.skype.com";

        private readonly IInternetSecurityManager internetSecurityManager = new InternetSecurityManager();
        private readonly RelayCommand toggleAdvertisementsBlockingCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            toggleAdvertisementsBlockingCommand = new RelayCommand((o) => ToggleAdvertisementsBlocking(o));
        }

        public bool IsAdvertisementsBlocked
        {
            get
            {
                IEnumString blockedSitesEnumerator;
                string[] blockedSites = new string[1000];
                IntPtr blockedSitesCount = IntPtr.Zero;

                internetSecurityManager.GetZoneMappings(UrlZone.Untrusted, out blockedSitesEnumerator, 0);

                blockedSitesEnumerator.Next(-1, blockedSites, blockedSitesCount);

                return blockedSites.Contains(SkypeAdvertisementsSite);
            }
        }


        private void ToggleAdvertisementsBlocking(object o)
        {
            internetSecurityManager.SetZoneMapping(UrlZone.Untrusted, SkypeAdvertisementsSite, this.IsAdvertisementsBlocked ? SetZoneMappingFlags.Unset : SetZoneMappingFlags.Set);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("IsAdvertisementsBlocked"));
            }

        }

        public ICommand ToggleAdvertisementsBlockingCommand
        {
            get { return toggleAdvertisementsBlockingCommand; }
        }


    }
}
