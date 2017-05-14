using System;

namespace build
{
    public interface IDeployment
    {
        IDeployment Call(string program, string args, int tries = 0);
        IDeployment ChangeDirectory(string directory);
        IDeployment ParallelCall(Func<IParallelDeployment, IDeployment> calls);
        IDeployment Copy(string source, string destination);
        IDeployment Publish();
        IRun Run();
    }
}