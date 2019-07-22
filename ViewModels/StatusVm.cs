namespace RhumbixAPIConnector.ViewModels
{
    public class StatusVm
    {
        public string StatusDetails { get; set; }
        public void GetStatus()
        {
            StatusDetails = FileSystemsHelpers.ReadFiles();
        }

        public StatusVm()
        {
            GetStatus();
        }
    }
}
