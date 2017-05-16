using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deploy.DeploymentSdk
{
    internal class ParallelDeployment : StandardDeployment, IParallelDeployment
    {
        public override IRun Run()
        {
            Parallel.ForEach(this.script, s => new Run(s.step, s.stopOnError));
            return new CompletedRun();
        }
    }
}