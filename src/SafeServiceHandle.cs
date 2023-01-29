using Microsoft.Win32.SafeHandles;

namespace DeleteService;

internal sealed class SafeServiceHandle : SafeHandleZeroOrMinusOneIsInvalid
{
    public SafeServiceHandle() : base(ownsHandle: true)
    {
    }

    public SafeServiceHandle(nint preexistingHandle, bool ownsHandle) : base(ownsHandle)
    {
        SetHandle(preexistingHandle);
    }

    protected override bool ReleaseHandle()
    {
        return Advapi32.CloseServiceHandle(handle);
    }
}
