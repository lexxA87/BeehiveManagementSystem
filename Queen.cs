namespace BeehiveManagementSystem
{
    internal class Queen : Bee
    {
        public Queen(string job) : base(job) { }

        public override float CostPerShift { get { return 2.15f; } }
        protected override void DoJob()
        {
            base.DoJob();
        }
    }
}
