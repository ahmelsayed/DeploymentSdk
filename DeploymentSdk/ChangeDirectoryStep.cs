using System;

namespace build.DeploymentSdk
{
    public class ChangeDirectoryStep : IStep
    {
        private string directory;

        public ChangeDirectoryStep(string directory)
        {
            this.directory = directory;
        }

        public IRun Run()
        {
            throw new NotImplementedException();
        }
    }
}