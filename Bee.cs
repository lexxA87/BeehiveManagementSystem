﻿namespace BeehiveManagementSystem
{
    abstract class Bee
    {
        public Bee(string job)
        {
            Job = job;
        }

        public string Job { get; private set; }

        public abstract float CostPerShift { get; }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift)) DoJob();
        }
        protected abstract void DoJob();
    }
}
