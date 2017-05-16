namespace Deploy.DeploymentSdk
{
    public static class DeploySdk
    {
        public static IDeployment StartOnlyProceedOnSuccess()
        {
            return new StandardDeployment();
        }
    }
}