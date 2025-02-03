using System.Diagnostics;

namespace NukeOneStart.Warheads.Interfaces
{
    public interface IProcessWarhead
    {
         public IEnumerable<Process> FindProcesses();           // Returns a list of process objects
         public IEnumerable<string> FindAndKillProcesses();     // Returns a list of process names that were killed in the operation
         public void KillProcesses();                           // Silently kills target processes
    }
}