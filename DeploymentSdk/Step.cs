using System;

namespace build.DeploymentSdk
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
            var program = Environment.ExpandEnvironmentVariables(this._program);
            var args = Environment.ExpandEnvironmentVariables(this._args);

            var executable = new Executable(program, args, streamOutput: false, shareConsole: true);

            run.Start();
            var statusCode = executable.Run();
            run.End();

            return statusCode != 0
                ? new FaultedRun(run)
                : run;
        }
    }
}