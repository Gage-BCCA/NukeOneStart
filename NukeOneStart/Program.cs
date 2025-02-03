using NukeOneStart.Warheads;

namespace NukeOneStart
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            OneStartProcessWarhead processWarhead = new OneStartProcessWarhead();
            OneStartFolderWarhead folderWarhead = new OneStartFolderWarhead();
            OneStartRegistryWarhead registryWarhead = new OneStartRegistryWarhead();

            processWarhead.KillProcesses();
            folderWarhead.FindAndDestroyFolders();
            registryWarhead.FindAndDestroyUserRegistryKeys();

            Console.WriteLine("OneStart has been nuked.");

        }

    }
}
