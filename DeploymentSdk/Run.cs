using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace build.DeploymentSdk
{
    internal class Run : IRun
    {
        private readonly IEnumerable<IStep> _script;
        private readonly Stopwatch _stopwatch;

        public Run() : this(Enumerable.Empty<IStep>())
        {
        }

        public Run(IEnumerable<IStep> script)
        {
            this._script = script;
            this._stopwatch = new Stopwatch();
        }

        internal void Start()
        {
            this._stopwatch.Start();
        }

        internal void End()
        {
            this._stopwatch.Stop();
        }
    }
}