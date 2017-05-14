using System;

namespace build.DeploymentSdk
{
    public class ParallelStep : Step
    {
        private Func<IParallelDeployment, IDeployment> calls;

        public ParallelStep(Func<IParallelDeployment, IDeployment> calls)
        {
            this.calls = calls;
        }
    }
}