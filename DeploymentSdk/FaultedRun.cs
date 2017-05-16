namespace Deploy.DeploymentSdk
{
    internal class FaultedRun : Run
    {
        private Run run;

        public FaultedRun(Run run)
        {
            this.run = run;
        }
    }
}