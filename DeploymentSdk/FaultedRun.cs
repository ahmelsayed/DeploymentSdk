namespace build.DeploymentSdk
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