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

        public void WorkTheNextShift(float honeyConsume)
        {
            if (HoneyVault.ConsumeHoney(honeyConsume)) DoJob();
        }
        protected virtual void DoJob()
        {
            // oveerrides subclasses
        }
    }
}
