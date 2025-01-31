using Microsoft.Win32;
using NukeOneStart.Warheads.Interfaces;

namespace NukeOneStart.Warheads
{
    public class OneStartRegistryHunter: IRegistryHunter
    {
        private string _targetRegistryKey = "\\software\\OneStart.ai";

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
                rk.DeleteSubKeyTree(key + _targetRegistryKey, false);
            }
            return;
        }

    }
}