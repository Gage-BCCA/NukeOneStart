using System.IO;
using System.Diagnostics;
using NukeOneStart.Warheads;
using NukeOneStart.Warheads.Interfaces;

namespace NukeOneStart
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            IProcessHunter processHunter = new OneStartProcessHunter();
            IFolderHunter folderHunter = new OneStartFolderHunter();
            IRegistryHunter registryHunter = new OneStartRegistryHunter();

            processHunter.KillProcesses();
            folderHunter.FindAndDestroyFolders();
            registryHunter.FindAndDestroyUserRegistryKeys();

            Console.WriteLine("OneStart has been nuked.");

        }

    }
}
