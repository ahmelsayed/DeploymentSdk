using System;

namespace Deploy.DeploymentSdk
{
    internal class CompletedRun : IRun
    {
        public void Start()
        {
        }

        public void End()
        {
        }

        public IRun OnFail(Action<IRun> action)
        {
            throw new NotImplementedException();
        }

        public IRun OnSuccess(Action<IRun> action)
        {
            throw new NotImplementedException();
        }
    }
}