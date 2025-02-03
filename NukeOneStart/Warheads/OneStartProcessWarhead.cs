using System.Diagnostics;
using NukeOneStart.Warheads.Interfaces;

namespace NukeOneStart.Warheads
{
    public class OneStartProcessWarhead : IProcessWarhead
    {

        private string _targetProcessName = "onestart";

        public IEnumerable<Process> FindProcesses()
            => GetTargetProcesses();


        public IEnumerable<string> FindAndKillProcesses()
        {
            List<string> killedProcesses = new List<string>();
            foreach (Process process in GetTargetProcesses())
            {
                killedProcesses.Add(process.ProcessName);
                process.Kill();
            }
            return killedProcesses;
        }

        public void KillProcesses()
        {
            foreach(Process process in GetTargetProcesses())
            {
                process.Kill();
            }
        }

        private IEnumerable<Process> GetTargetProcesses()
        {
            // Grab all running processes
            Process[] allLocal = Process.GetProcesses();

            List<Process> foundProcesses = new List<Process>();

            // Here we grab all the matching processes and 
            // append them to our list to return
            foreach (Process process in allLocal)
            {
                if (process.ProcessName.Equals(_targetProcessName))
                {
                    foundProcesses.Add(process);
                }
            }

            return foundProcesses;
        }
    }
}