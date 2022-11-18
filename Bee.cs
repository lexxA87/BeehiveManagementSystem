namespace BeehiveManagementSystem
{
    internal class Bee
    {
        public Bee(string job)
        {
            Job = job;
        }

        public string Job { get; private set; }

        public virtual float CostPerShift { get; private set; }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift)) DoJob();
        }
        protected virtual void DoJob()
        {
            // oveerrides subclasses
        }
    }
}
