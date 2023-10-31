using System;
using Microsoft.Win32;

class Program
{
    private static readonly int value = 65;

    static void Main(string[] args)
    {
        try
        {
            using (RegistryKey regKeyIPv4 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip\Parameters", true))
            {
                if (regKeyIPv4 == null)
                {
                    Console.WriteLine("Registry key for IPv4 could not be found!");
                    return;
                }

                regKeyIPv4.SetValue("DefaultTTL", value, RegistryValueKind.DWord);
                Console.WriteLine($"TTL value for IPv4 changed to {value}.");
            }

            using (RegistryKey regKeyIPv6 = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\Tcpip6\Parameters", true))
            {
                if (regKeyIPv6 == null)
                {
                    Console.WriteLine("Registry key for IPv6 could not be found!");
                    return;
                }

                regKeyIPv6.SetValue("DefaultTTL", value, RegistryValueKind.DWord);
                Console.WriteLine($"TTL value for IPv6 changed to {value}.");
            }

            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}