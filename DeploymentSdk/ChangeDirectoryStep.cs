namespace build.DeploymentSdk
{
    public class ChangeDirectoryStep : Step
    {
        private string directory;

        public ChangeDirectoryStep(string directory)
        {
            this.directory = directory;
        }
    }
}