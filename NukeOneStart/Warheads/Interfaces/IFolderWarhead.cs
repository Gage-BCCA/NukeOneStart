namespace NukeOneStart.Warheads.Interfaces
{
    public interface IFolderWarhead
    {
        public void FindAndDestroyFolders();    // Destroys both OneStart app data folders and the OneStart task in the Task Scheduler folder
    }
}