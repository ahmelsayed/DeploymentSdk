using System;

namespace Deploy.DeploymentSdk
{
    public class ParallelStep : IStep
    {
        private Func<IParallelDeployment, IDeployment> calls;

        public ParallelStep(Func<IParallelDeployment, IDeployment> calls)
        {
            this.calls = calls;
        }

        public IRun Run()
        {
            var parallelDeployment = new ParallelDeployment();
            return calls(parallelDeployment).Run();
        }
    }
}