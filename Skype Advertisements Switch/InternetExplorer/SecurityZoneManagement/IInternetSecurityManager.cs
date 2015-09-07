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
        /// <summary>
        /// Sets the security site manager.
        /// </summary>
        /// <param name="pSite">The address of the <c>IInternetSecurityMgrSite</c> interface to set.</param>
        void SetSecuritySite([In] IntPtr pSite);

        /// <summary>
        /// Gets the security site manager.
        /// </summary>
        /// <param name="pSite">A pointer to the current <c>IInternetSecurityMgrSite</c> interface.</param>
        void GetSecuritySite([Out] IntPtr pSite);

        /// <summary>
        /// Gets the zone index for the specified URL.
        /// </summary>
        /// <param name="pwszUrl">A string value that contains the URL.</param>
        /// <param name="pdwZone">The security zone.</param>
        /// <param name="dwFlags">An unsigned long integer value that specifies <see cref="MapUrlToZoneFlags"/> to control the mapping.</param>
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

        /// <summary>
        /// Determines the policy for the specified action and displays a user interface, if the policy indicates that the user should be queried.
        /// </summary>
        /// <param name="pwszUrl">A constant pointer to a wide character string that specifies the URL.</param>
        /// <param name="dwAction">
        /// A <see cref="uint"/> that specifies the action to be performed. This can be one of the URL Action Flags values.
        /// <para />
        /// See <seealso cref="https://msdn.microsoft.com/en-us/library/ms537178(v=vs.85).aspx"/> for more information.
        /// </param>
        /// <param name="pPolicy">
        /// Required. A pointer to a buffer that receives the policy and action for the specified URL. This must be one of the URL Policy Flags values.
        /// <para />
        /// See <seealso cref="https://msdn.microsoft.com/en-us/library/ms537179(v=vs.85).aspx"/> for more information.
        /// </param>
        /// <param name="cbPolicy">A <see cref="uint"/> that specifies the size of the buffer pPolicy.</param>
        /// <param name="pContext">A pointer to a buffer that contains the context information (a CLSID) used by the delegation routines. Can be set to <c>null</c>.</param>
        /// <param name="cbContext">A <see cref="uint"/> that specifies the size of the buffer cbContext.</param>
        /// <param name="dwFlags">
        /// A <see cref="uint"/> that specifies a PUAF enumeration value or values.
        /// <para />
        /// See <seealso cref="https://msdn.microsoft.com/en-us/library/ms537171(v=vs.85).aspx"/> for more information.
        /// </param>
        /// <param name="dwReserved">Reserved. Must be set to 0.</param>
        void ProcessUrlAction([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [In] uint dwAction, [Out] out byte pPolicy, [In] uint cbPolicy, [In] byte pContext, [In] uint cbContext, [In] uint dwFlags, [In] uint dwReserved);

        /// <summary>
        /// Gets the custom policy associated with the URL and specified key in the given context.
        /// </summary>
        /// <param name="pwszUrl">A pointer to a string value that specifies the URL.</param>
        /// <param name="guidKey">A globally unique identifier associated with the custom policy.</param>
        /// <param name="ppPolicy">A pointer to the buffer to store the policy information.</param>
        /// <param name="pcbPolicy">A pointer to an unsigned long integer value that specifies the policy buffer size.</param>
        /// <param name="pContext">A pointer to a buffer that specifies the context information.</param>
        /// <param name="cbContext">An unsigned long integer value that specifies the size of the context buffer.</param>
        /// <param name="dwReserved">Reserved. Must be set to 0.</param>
        void QueryCustomPolicy([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [In] ref Guid guidKey, [In] ref byte ppPolicy, [In] ref uint pcbPolicy, [In] ref byte pContext, [In] uint cbContext, [In] uint dwReserved);

        /// <summary>
        /// Maps a pattern into the specified zone.
        /// </summary>
        /// <param name="dwZone">The security zone.</param>
        /// <param name="lpszPattern">
        /// A string value that contains the URL pattern with a limited number of wildcards.
        /// <para />
        /// See <seealso cref="https://msdn.microsoft.com/en-us/library/ms537143(v=vs.85).aspx"/> for possible patterns.
        /// </param>
        /// <param name="dwFlags">The flag to define whether an add or a delete will be executed.</param>
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
