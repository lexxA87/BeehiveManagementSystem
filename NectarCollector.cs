namespace BeehiveManagementSystem
{
    internal class NectarCollector : Bee
    {
        const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;
        public NectarCollector(string job) : base(job) { }

        public override float CostPerShift { get { return 1.95f; } }
        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
        }
    }
}
