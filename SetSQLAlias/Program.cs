using System;
using System.Linq;
using Microsoft.Win32;

namespace SetSQLAlias
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 2)
            {
                Console.WriteLine("The SQL Alias and Server name must be passed in.");
                return;
            }

            string SQLAlias = args[0];
            string Server = "DBMSSOCN," + args[1];

            RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\MSSQLServer\Client\ConnectTo");
            key.SetValue(SQLAlias, Server);
            key.Close();

            if (Environment.Is64BitOperatingSystem)
            {
                RegistryKey key2 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Wow6432Node\Microsoft\MSSQLServer\Client\ConnectTo");
                key2.SetValue(SQLAlias, Server);
                key2.Close();
            }
                
        }
    }
}
