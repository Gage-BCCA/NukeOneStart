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
            // IProcessHunter oneStartHunter = new OneStartProcessHunter();

            // IEnumerable<string> killResults = oneStartHunter.FindAndKillProcesses();

            // foreach(string name in killResults)
            // {
            //     Console.WriteLine(name);
            // }

            OneStartRegistryHunter hunter = new();
            hunter.FindAndDestroyUserRegistryKeys();

        }

    }
}
