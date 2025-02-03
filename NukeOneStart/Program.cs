using NukeOneStart.Warheads;
using NukeOneStart.Warheads.Interfaces;

namespace NukeOneStart
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            OneStartProcessHunter processHunter = new OneStartProcessHunter();
            OneStartFolderHunter folderHunter = new OneStartFolderHunter();
            OneStartRegistryHunter registryHunter = new OneStartRegistryHunter();

            processHunter.KillProcesses();
            folderHunter.FindAndDestroyFolders();
            registryHunter.FindAndDestroyUserRegistryKeys();

            Console.WriteLine("OneStart has been nuked.");

        }

    }
}
