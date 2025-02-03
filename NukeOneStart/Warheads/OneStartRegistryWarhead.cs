using Microsoft.Win32;
using NukeOneStart.Warheads.Interfaces;

namespace NukeOneStart.Warheads
{
    public class OneStartRegistryWarhead: IRegistryWarhead
    {
        private string _targetUserRegistryKey = "\\software\\OneStart.ai";
        private string _targetScheduledTaskRegistryHive = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Schedule\\TaskCache\\Tasks";

        public void FindAndDestroyUserRegistryKeys()
        {
            // This is simple with the Windows API wrapper
            // but requires elevated permissions.

            // Grab the Users Hive and all the immediate subkeys.
            // We'll iterate the subkeys and try to delete the
            // OneStart key. We'll silently fail out if the
            // key doesn't exist.
            RegistryKey rk = Registry.Users;
            string[] userKeys = rk.GetSubKeyNames();
            foreach(string key in userKeys)
            {
                // Todo: Handle errors instead of silently failing
                rk.DeleteSubKeyTree(key + _targetUserRegistryKey, false);
            }
            return;
        }


        public void FindAndDestroyScheduledTaskRegistryKeys()
        {
        /*

            This function iterates the Task Scheduler cache in the registry. However, since 
            even the built in administrator account does not have permissions to edit/delete
            the keys, this function is not used and is not complete. 

        */
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(_targetScheduledTaskRegistryHive, false);
            foreach (string key in rk.GetSubKeyNames())
            {
                Console.WriteLine(key);
            }
            Console.ReadLine();
            return;
        }

    }
}