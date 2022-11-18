namespace BeehiveManagementSystem
{
    internal class NectarCollector : Bee
    {
        public NectarCollector(string job) : base(job) { }

        public override float CostPerShift { get { return 1.95f; } }
        protected override void DoJob()
        {
            base.DoJob();
        }
    }
}
