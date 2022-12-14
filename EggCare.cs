namespace BeehiveManagementSystem
{
    internal class EggCare : Bee
    {
        const float CARE_PROGRESS_PER_SHIFT = 0.15f;
        private Queen queen;
        public EggCare(Queen queen) : base("Egg Care")
        {
            this.queen = queen;
        }

        public override float CostPerShift { get { return 1.35f; } }
        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
