using System.Runtime.InteropServices;

namespace DeleteService;

internal static partial class Advapi32
{
#if NET7_0_OR_GREATER
    [LibraryImport(nameof(Advapi32), SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool CloseServiceHandle(nint hSCObject);

    [LibraryImport(nameof(Advapi32), SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool DeleteService(SafeServiceHandle hService);

    [LibraryImport(nameof(Advapi32), EntryPoint = "OpenSCManagerW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    internal static partial SafeServiceHandle OpenSCManager(
        string? lpMachineName,
        string? lpDatabaseName,
        uint dwDesiredAccess);

    [LibraryImport(nameof(Advapi32), EntryPoint = "OpenServiceW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    internal static partial SafeServiceHandle OpenService(
        SafeServiceHandle hSCManager,
        string lpServiceName,
        uint dwDesiredAccess);
#else
    [DllImport(nameof(Advapi32), SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool CloseServiceHandle(nint hSCObject);

    [DllImport(nameof(Advapi32), SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static extern bool DeleteService(SafeServiceHandle hService);

    [DllImport(nameof(Advapi32), EntryPoint = "OpenSCManagerW", CharSet = CharSet.Unicode, SetLastError = true)]
    internal static extern SafeServiceHandle OpenSCManager(
        string? lpMachineName,
        string? lpDatabaseName,
        uint dwDesiredAccess);

    [DllImport(nameof(Advapi32), EntryPoint = "OpenServiceW", CharSet = CharSet.Unicode, SetLastError = true)]
    internal static extern SafeServiceHandle OpenService(
        SafeServiceHandle hSCManager,
        string lpServiceName,
        uint dwDesiredAccess);
#endif
}
