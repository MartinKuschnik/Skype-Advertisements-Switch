namespace SkypeAdvertisementsSwitch.InternetExplorer.SecurityZoneManagement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal enum UrlZone : uint
    {
        LocalMachine = 0,
        Intranet = 1,
        Trusted = 2,
        Internet = 3,
        Untrusted = 4,
    }
}
