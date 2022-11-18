namespace BeehiveManagementSystem
{
    internal class EggCare : Bee
    {
        public EggCare(string job) : base(job) { }

        public override float CostPerShift { get { return 1.35f; } }
        protected override void DoJob()
        {
            base.DoJob();
        }
    }
}
