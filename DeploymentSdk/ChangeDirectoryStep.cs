namespace build.DeploymentSdk
{
    public class ChangeDirectoryStep : IStep
    {
        private string directory;

        public ChangeDirectoryStep(string directory)
        {
            this.directory = directory;
        }
    }
}