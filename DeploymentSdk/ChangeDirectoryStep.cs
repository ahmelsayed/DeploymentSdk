using System;

namespace Deploy.DeploymentSdk
{
    public class ChangeDirectoryStep : IStep
    {
        private string directory;

        public ChangeDirectoryStep(string directory)
        {
            this.directory = Environment.ExpandEnvironmentVariables(directory);
        }

        public IRun Run()
        {
            System.IO.Directory.SetCurrentDirectory(directory);
            return new CompletedRun();
        }
    }
}