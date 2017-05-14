using System;

namespace build.DeploymentSdk
{
    public class ParallelStep : IStep
    {
        private Func<IParallelDeployment, IDeployment> calls;

        public ParallelStep(Func<IParallelDeployment, IDeployment> calls)
        {
            this.calls = calls;
        }
    }
}