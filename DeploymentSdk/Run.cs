using System.Collections.Generic;

namespace build.DeploymentSdk
{
    internal class Run : IRun
    {
        private IList<IStep> script;

        public Run(IList<IStep> script)
        {
            this.script = script;
        }
    }
}