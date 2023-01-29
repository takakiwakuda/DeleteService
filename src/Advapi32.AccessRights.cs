namespace DeleteService;

internal static partial class Advapi32
{
    internal static class AccessRights
    {
        #region Service Control Manager
        internal const uint SC_MANAGER_ALL_ACCESS = 0xF003F;
        #endregion

        #region Service
        internal const uint DELETE = 0x10000;
        #endregion
    }
}
