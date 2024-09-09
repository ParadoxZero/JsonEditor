using System;
using System.Runtime.InteropServices;
using System.Security;

public static class SecureStringExtensions
{
    public static string ToUnsecureString(this SecureString securePassword)
    {
        if (securePassword == null)
            throw new ArgumentNullException(nameof(securePassword));

        IntPtr unmanagedString = IntPtr.Zero;
        try
        {
            // Marshal the SecureString to an unmanaged memory block
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
            // Convert the unmanaged memory block to a managed string
            return Marshal.PtrToStringUni(unmanagedString);
        }
        finally
        {
            // Zero out and free the unmanaged memory block
            Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        }
    }
}
