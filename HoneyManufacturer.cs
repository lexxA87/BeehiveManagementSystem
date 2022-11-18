namespace BeehiveManagementSystem
{
    internal class HoneyManufacturer : Bee
    {
        public HoneyManufacturer(string job) : base(job) { }

        public override float CostPerShift { get { return 1.7f; } }
        protected override void DoJob()
        {
            base.DoJob();
        }
    }
}
