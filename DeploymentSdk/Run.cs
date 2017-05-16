using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Deploy.DeploymentSdk
{
    internal class Run : IRun
    {
        private readonly IEnumerable<(IStep step, bool stopOnError)> _script;
        private readonly Action _onFail;
        private readonly Action _onSuccess;
        private readonly Stopwatch _stopwatch;
        private readonly StringBuilder _stringBuilder;
        public string Logs => _stringBuilder.ToString();

        public Run() : this(Enumerable.Empty<(IStep, bool)>())
        {
        }

        public Run(IStep step, bool stopOnError) : this (new [] { (step, stopOnError )})
        {
        }

        public Run(IEnumerable<(IStep step, bool stopOnError)> script, Action onSuccess = null, Action onFail = null)
        {
            this._script = script;
            this._stopwatch = new Stopwatch();
            this._stringBuilder = new StringBuilder();
            this._onFail = onFail;
            this._onSuccess = onSuccess;
            DoRun();
        }

        private void DoRun()
        {
            if (this._script.Any())
            {
                Start();
                foreach((var step, var stopOnError) in _script)
                {
                    var result = step.Run();
                    if (result is FaultedRun && stopOnError)
                    {
                        this._onFail?.Invoke();
                        End();
                        return;
                    }
                }
                this._onSuccess?.Invoke();
                End();
                return;
            }
        }

        public void Start()
        {
            this._stopwatch.Start();
        }

        public void End()
        {
            this._stopwatch.Stop();
        }
    }
}