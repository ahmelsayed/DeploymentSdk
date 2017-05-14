using System;

namespace build.DeploymentSdk
{
    public class Step : IStep
    {
        private readonly int _tries;
        private readonly string _args;
        private readonly string _program;

        public Step()
        {

        }
        
        public Step(string program, string args, int tries)
        {
            this._program = program;
            this._args = args;
            this._tries = tries;
        }

        public virtual IRun Run()
        {
            throw new NotImplementedException();
        }
    }
}