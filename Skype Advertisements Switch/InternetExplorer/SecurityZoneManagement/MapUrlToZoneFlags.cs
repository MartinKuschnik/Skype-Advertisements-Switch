namespace SkypeAdvertisementsSwitch.InternetExplorer.SecurityZoneManagement
{
    /// <summary>
    /// Values that control the action of <see cref="IInternetSecurityManager.MapUrlToZone"/>
    /// </summary>
    internal enum MapUrlToZoneFlags : uint
    {
        /// <summary>
        /// Indicates that the file should not be checked for the MOTW.
        /// </summary>
        NoSavedFileCeck = 0x00000001,

        /// <summary>
        /// Internet Explorer 6 for Windows XP SP2 and later.Indicates that the URL is a file and "file:" does not need to be prepended.
        /// </summary>
        IsFile = 0x00000002,

        /// <summary>
        /// Internet Explorer 6 for Windows XP SP2 and later.Indicates that wildcard characters can be used.
        /// </summary>
        AcceptWildcardScheme = 0x00000080,

        /// <summary>
        /// Indicates that the URL should be treated as if it were in the Restricted sites zone.
        /// </summary>
        EnforceRestricted = 0x00000100,

        /// <summary>
        /// Internet Explorer 7. Reserved. Do not use.
        /// </summary>
        Reserved = 0x00000200,

        /// <summary>
        /// Internet Explorer 6 for Windows XP SP2 and later.Always evaluate the "saved from url" (MOTW) information in the file.By setting this flag, you override the FEATURE_UNC_SAVEDFILECHECK feature control setting.
        /// </summary>
        RequireSavedFileCheck = 0x00000400,

        /// <summary>
        /// Internet Explorer 6 for Windows XP SP2 and later.Do not unescape the URL.
        /// </summary>
        DontUnescape = 0x00000800,

        /// <summary>
        /// Internet Explorer 7. Do not check the local Internet cache.
        /// </summary>
        DontUseCache = 0x00001000,

        /// <summary>
        /// Internet Explorer 7. Force the intranet flags to be active.Implies MUTZ_DONT_USE_CACHE.
        /// </summary>
        ForceIntranet = 0x00002000,

        /// <summary>
        /// Internet Explorer 7. Ignore all zone mappings that the user or administrator has set in the registry, including those set by ESC.For example, a site in the Trusted Sites zone would appear to be in the Internet zone (or whatever zone it was in originally). Implies MUTZ_DONT_USE_CACHE.
        /// </summary>
        IgnoreZoneMappings = 0x00004000,
    }
}


