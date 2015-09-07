namespace SkypeAdvertisementsSwitch.InternetExplorer.SecurityZoneManagement
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;

    [ComImport]
    [Guid("7b8a2d94-0ac9-11d1-896c-00c04fb6bfc4")]
    internal class InternetSecurityManager : IInternetSecurityManager
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern void GetSecurityId([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [In, MarshalAs(UnmanagedType.LPArray)] byte[] pbSecurityId, [In] ref uint pcbSecurityId, [In] uint dwReserved);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern void GetSecuritySite([Out] IntPtr pSite);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern void GetZoneMappings([In] UrlZone dwZone, [Out] out IEnumString ppenumString, [In] uint dwFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern void MapUrlToZone([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [In] ref UrlZone pdwZone, [In] MapUrlToZoneFlags dwFlags);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern void ProcessUrlAction([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [In] uint dwAction, [Out] out byte pPolicy, [In] uint cbPolicy, [In] byte pContext, [In] uint cbContext, [In] uint dwFlags, [In] uint dwReserved);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern void QueryCustomPolicy([In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl, [In] ref Guid guidKey, [In] ref byte ppPolicy, [In] ref uint pcbPolicy, [In] ref byte pContext, [In] uint cbContext, [In] uint dwReserved);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern void SetSecuritySite([In] IntPtr pSite);
        
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public extern void SetZoneMapping([In] UrlZone dwZone, [In, MarshalAs(UnmanagedType.LPWStr)] string lpszPattern, [In] SetZoneMappingFlags dwFlags);
    }
}
