namespace SkypeAdvertisementsSwitch.InternetExplorer.SecurityZoneManagement
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    /// <summary>
    /// Enables client applications to determine the security of the browser components.
    /// </summary>
    [ComImport]
    [Guid("79EAC9EE-BAF9-11CE-8C82-00AA004BA90B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IInternetSecurityManager
    {
        void SetSecuritySite([In] IntPtr pSite);

        void GetSecuritySite([Out] IntPtr pSite);

        void MapUrlToZone([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [In] ref UrlZone pdwZone, [In] MapUrlToZoneFlags dwFlags);

        /// <summary>
        /// Gets the security identification of the specified URL.
        /// </summary>
        /// <param name="pwszUrl">A string value that specifies the URL.</param>
        /// <param name="pbSecurityId">A buffer that specifies the scheme, domain name, and zone associated with the URL.</param>
        /// <param name="pcbSecurityId">An unsigned long integer value that specifies the size of the buffer being passed in.</param>
        /// <param name="dwReserved">
        /// An unsigned long integer that specifies the domain to use. 
        /// If set to zero, the full domain name is used. Otherwise, a string value containing a suffix to the domain name can be specified. 
        /// This larger domain name—the full domain name combined with the suffix—is used as the security identifier.
        /// </param>
        void GetSecurityId([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [In, MarshalAs(UnmanagedType.LPArray)] byte[] pbSecurityId, [In] ref uint pcbSecurityId, [In] uint dwReserved);

        void ProcessUrlAction([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [In] uint dwAction, [Out] out byte pPolicy, [In] uint cbPolicy, [In] byte pContext, [In] uint cbContext, [In] uint dwFlags, [In] uint dwReserved);

        void QueryCustomPolicy([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [In] ref Guid guidKey, [In] ref byte ppPolicy, [In] ref uint pcbPolicy, [In] ref byte pContext, [In] uint cbContext, [In] uint dwReserved);

        /// <summary>
        /// Sets the zone mapping.
        /// </summary>
        /// <param name="dwZone">The dw zone.</param>
        /// <param name="lpszPattern">The LPSZ pattern.</param>
        /// <param name="dwFlags">The dw flags.</param>
        void SetZoneMapping([In] UrlZone dwZone, [In, MarshalAs(UnmanagedType.LPWStr)] string lpszPattern, [In] SetZoneMappingFlags dwFlags);

        /// <summary>
        /// Gets the complete set of patterns mapped to a zone.
        /// </summary>
        /// <param name="dwZone">The security zone.</param>
        /// <param name="ppenumString">An instance of the IEnumString interface that enumerates the strings for the security zone mappings.</param>
        /// <param name="dwFlags">Reserved. Must be set to 0.</param>
        void GetZoneMappings([In] UrlZone dwZone, [Out] out IEnumString ppenumString, [In] uint dwFlags);
    }
}
