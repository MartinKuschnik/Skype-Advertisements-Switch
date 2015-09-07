namespace SkypeAdvertisementsSwitch.InternetExplorer.SecurityZoneManagement
{
    /// <summary>
    /// Contains some of the predefined zones used by Windows Internet Explorer.
    /// <para />
    /// See <seealso cref="https://msdn.microsoft.com/de-de/library/ms537175(v=vs.85).aspx"/> for all values.
    /// </summary>
    internal enum UrlZone : uint
    {
        /// <summary>
        /// Zone used for content already on the user's local computer. This zone is not exposed by the user interface.
        /// </summary>
        LocalMachine = 0,

        /// <summary>
        /// Zone used for content found on an intranet.
        /// </summary>
        Intranet = 1,

        /// <summary>
        /// Zone used for trusted Web sites on the Internet.
        /// </summary>
        Trusted = 2,

        /// <summary>
        /// Zone used for most of the content on the Internet.
        /// </summary>
        Internet = 3,

        /// <summary>
        /// Zone used for Web sites that are not trusted.
        /// </summary>
        Untrusted = 4,
    }
}
