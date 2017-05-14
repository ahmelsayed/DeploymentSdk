namespace build.DeploymentSdk
{
    public class CopyStep : IStep
    {
        private string source;
        private string destination;

        public CopyStep(string source, string destination)
        {
            this.source = source;
            this.destination = destination;
        }
    }
}