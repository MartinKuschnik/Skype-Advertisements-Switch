namespace SkypeAdvertisementsSwitch.InternetExplorer.SecurityZoneManagement
{
    /// <summary>
    /// Flag to control the behavior of the <see cref="IInternetSecurityManager.SetZoneMapping(UrlZone, string, SetZoneMappingFlags)"/> method.
    /// </summary>
    internal enum SetZoneMappingFlags : uint
    {
        /// <summary>
        /// Use this flag to add a URL a pattern from a zone.
        /// </summary>
        Create,

        /// <summary>
        /// Use this flag to delete a URL or a pattern from a zone.
        /// </summary>
        Delete
    }
}
