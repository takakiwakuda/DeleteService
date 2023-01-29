using System;
using System.ComponentModel;

namespace DeleteService;

public static class ServiceControl
{
    /// <summary>
    /// Deletes a Windows service with the specified name.
    /// </summary>
    /// <param name="name">The name of the service to delete.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="name"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// <paramref name="name"/> is empty.
    /// </exception>
    /// <exception cref="Win32Exception">
    /// An error occurred when accessing a Windows API.
    /// </exception>
    public static void DeleteService(string name)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (name.Length == 0)
        {
            throw new ArgumentException("The value cannot be an empty string.", nameof(name));
        }

        using var managerHandle = Advapi32.OpenSCManager(null, null, Advapi32.AccessRights.SC_MANAGER_ALL_ACCESS);
        if (managerHandle.IsInvalid)
        {
            throw new Win32Exception();
        }

        using var serviceHandle = Advapi32.OpenService(managerHandle, name, Advapi32.AccessRights.DELETE);
        if (serviceHandle.IsInvalid)
        {
            throw new Win32Exception();
        }

        if (!Advapi32.DeleteService(serviceHandle))
        {
            throw new Win32Exception();
        }
    }
}
