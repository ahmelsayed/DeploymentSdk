using System;

namespace Deploy.DeploymentSdk
{
    public class ActionStep : IStep
    {
        private readonly Action _run;
        private readonly string _name;

        public ActionStep(Action run, string name)
        {
            this._run = run;
            this._name = name ?? "Unnamed action step.";
        }

        public IRun Run()
        {
            var run = new Run();
            try
            {
                StaticLogger.WriteLine($"Starting step: {this._name}");
                run.Start();
                this._run();
                run.End();
                StaticLogger.WriteLine($"Finished step: {this._name}");
                return run;
            }
            catch (Exception e)
            {
                StaticLogger.WriteErrorLine($"Error in step: {this._name}, error: {e.ToString()}");
                run.End();
                return new FaultedRun(run);
            }
        }
    }
}