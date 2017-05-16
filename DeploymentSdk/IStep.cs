using System;

namespace Deploy.DeploymentSdk
{
    public interface IStep
    {
        IRun Run();
    }
}