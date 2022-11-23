using System;
using System.ComponentModel;

namespace BeehiveManagementSystem
{
    internal class Queen : Bee, INotifyPropertyChanged
    {
        const float EGGS_PER_SHIFT = 0.45f;
        const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
        public Queen() : base("Queen")
        {
            AssignBee("Nectar Collector");
            AssignBee("Honey Manufacturer");
            AssignBee("Egg Care");
            UpdateStatusReport();
        }

        public override float CostPerShift { get { return 2.15f; } }

        private IWorker[] workers = Array.Empty<IWorker>();
        private float unassignedWorkers = 3.0f;
        private float eggs = 0.0f;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string StatusReport { get; private set; } = "";

        private void UpdateStatusReport()
        {
            IWorker[] nectarCollector = Array.FindAll(workers, worker => worker.Job == "Nectar Collector");
            IWorker[] honeyManufacturer = Array.FindAll(workers, worker => worker.Job == "Honey Manufacturer");
            IWorker[] eggsCare = Array.FindAll(workers, worker => worker.Job == "Egg Care");

            string honeyAndNektarReport = HoneyVault.StatusReport;

            string beesReport = $"\nEgg count: {eggs: 0.00}\nUnassigned workers: {unassignedWorkers: 0.0}\n" +
                $"{nectarCollector.Length} Nectar Collector bee{MultWord(nectarCollector.Length)}\n" +
                $"{honeyManufacturer.Length} Honey Manufacturer bee{MultWord(honeyManufacturer.Length)}\n" +
                $"{eggsCare.Length} Egg Care bee{MultWord(eggsCare.Length)}\n" +
                $"TOTAL WORKERS: {workers.Length}\n";

            StatusReport = honeyAndNektarReport + beesReport;
            OnPropertyChanged("StatusReport");
        }
        private void AddWorker(IWorker worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[^1] = worker;
            }
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
                default: break;
            }
            UpdateStatusReport();
        }
        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (IWorker worker in workers)
            {
                worker.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);
            UpdateStatusReport();
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert && eggs > 0)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        private string MultWord(int length)
        {
            if (length > 1) return "s";
            else return "";
        }
    }
}
