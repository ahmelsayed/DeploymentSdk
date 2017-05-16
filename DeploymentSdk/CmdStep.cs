using System;

namespace Deploy.DeploymentSdk
{
    public class CmdStep : IStep
    {
        private readonly int _tries;
        private readonly string _args;
        private readonly string _program;

        public CmdStep(string program, string args, int tries)
        {
            this._program = program;
            this._args = args;
            this._tries = tries;
        }

        public virtual IRun Run()
        {
            var run = new Run();
            var statusCode = InternalRun(run);
            return statusCode != 0
                ? new FaultedRun(run)
                : run;
        }

        protected int InternalRun(IRun run = null)
        {
            var program = Environment.ExpandEnvironmentVariables(this._program);
            var args = Environment.ExpandEnvironmentVariables(this._args);

            var executable = new Executable("cmd", $"/c \"{program} {args}\"", streamOutput: true);

            run?.Start();
            var statusCode = executable.Run(StaticLogger.WriteLine, StaticLogger.WriteErrorLine);
            run?.End();

            return statusCode;
        }
    }
}