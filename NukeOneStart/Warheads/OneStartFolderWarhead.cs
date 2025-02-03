using NukeOneStart.Warheads.Interfaces;

namespace NukeOneStart.Warheads
{
    public class OneStartFolderWarhead: IFolderWarhead
    {
        private string _targetFolderPath = "\\AppData\\Local\\OneStart.ai";
        private string _userFolderPath = "C:\\Users\\";
        private string _scheduledTasksFolderPath = "C:\\Windows\\System32\\Tasks";

        public void FindAndDestroyFolders()
        {
            
            List<string>userProfiles = GetAllUserProfiles();

            // Iterate through every gathered folder
            // and check if the OneStart folder exists.
            foreach (string user in userProfiles)
            {
                string target = _userFolderPath + user + _targetFolderPath;

                DirectoryInfo dirQuery = new DirectoryInfo(target);

                // If the target exists, destroy it.
                if (dirQuery.Exists)
                {
                    dirQuery.Delete(true);
                }
            }

            DirectoryInfo scheduledTasksDir = new DirectoryInfo(_scheduledTasksFolderPath);
            foreach (FileInfo task in scheduledTasksDir.GetFiles())
            {
                if (task.Name.Contains("OneStart"))
                {
                    task.Delete();
                }
            }
            return;
        }

        private List<string> GetAllUserProfiles()
        {
            List<string> userProfiles = new();

            // Gather the list of folders we must query against.
            // This will grab every folder in C:\Users, and we check later if 
            // the OneStart folder exists.
            DirectoryInfo dir = new DirectoryInfo(_userFolderPath);
            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {
                userProfiles.Add(subdir.Name);
            }

            return userProfiles;
        }
    }
}