using System;
using System.Collections.Generic;

namespace build.DeploymentSdk
{
    public class StandardDeployment : IDeployment
    {
        private IList<IStep> script = new List<IStep>();

        public IDeployment Call(string program, string args, int tries = 0)
        {
            script.Add(new Step(program, args, tries));
            return this;
        }

        public IDeployment ChangeDirectory(string directory)
        {
            script.Add(new ChangeDirectoryStep(directory));
            return this;
        }

        public IDeployment Copy(string source, string destination)
        {
            script.Add(new CopyStep(source, destination));
            return this;
        }

        public IDeployment ParallelCall(Func<IParallelDeployment, IDeployment> calls)
        {
            script.Add(new ParallelStep(calls));
            return this;
        }

        public IDeployment Publish()
        {
            script.Add(new PublishStep());
            return this;
        }

        public IRun Run()
        {
            return new Run(script);
        }
    }
}