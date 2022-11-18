using System;

namespace BeehiveManagementSystem
{
    internal class Queen : Bee
    {
        const float EGGS_PER_SHIFT = 0.45f;
        const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
        public Queen(string job) : base(job)
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
        }

        public override float CostPerShift { get { return 2.15f; } }

        private Bee[] workers = Array.Empty<Bee>();
        private float unassignedWorkers;
        private float eggs;

        private string UpdateStatusReport()
        {
            Bee[] nectarCollector = Array.FindAll(workers, worker => worker.Job == "Nectar Collector");
            Bee[] honeyManufacturer = Array.FindAll(workers, worker => worker.Job == "Honey Manufacturer");
            Bee[] eggsCare = Array.FindAll(workers, worker => worker.Job == "Egg Care");
            string honeyAndNektarReport = HoneyVault.StatusReport;
            string beesReport = $"\nEgg count: {eggs: 0.0}\nUnassigned workers: {unassignedWorkers: 0.0}" +
                $"{nectarCollector.Length} Nectar Collector bee\n{honeyManufacturer.Length} Honey manufacturer bee\n" +
                $"{eggsCare.Length} Egg care bee\nTOTAL WORKERS: {workers.Length}\n";
            return honeyAndNektarReport + beesReport;
        }
        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[^1] = worker;
            }
        }

        private void AssignBee(string job)
        {
            switch (job)
            {
                case "Nectar Collector":
                    AddWorker(new EggCare(job));
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer(job));
                    break;
                case "Egg Care":
                    AddWorker(new EggCare(job));
                    break;
                default: break;
            }
            UpdateStatusReport();
        }
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee worker in workers)
            {
                worker.WorkTheNextShift(worker.CostPerShift);
            }
            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * workers.Length);
            UpdateStatusReport();
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }
    }
}
