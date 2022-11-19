namespace BeehiveManagementSystem
{
    internal class HoneyManufacturer : Bee
    {
        const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;
        public HoneyManufacturer() : base("Honey Manufacturer") { }

        public override float CostPerShift { get { return 1.7f; } }
        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
