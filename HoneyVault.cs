namespace BeehiveManagementSystem
{
    internal static class HoneyVault
    {
        const float NECTAR_CONVERSION_RATIO = .19f;
        const float LOW_LEVEL_WARNING = 10f;

        private static float honey = 25f;
        private static float nectar = 100f;

        public static string StatusReport
        {
            get
            {
                string warningHoney = "LOW HONEY — ADD A HONEY MANUFACTURER\n";
                string warningNectar = "LOW NECTAR — ADD A NECTAR MANUFACTURER\n";
                string report = $"{honey:0.0} units of honey\n{nectar:0.0} units of nectar\n";
                if (honey < LOW_LEVEL_WARNING && nectar < LOW_LEVEL_WARNING)
                {
                    return report + warningHoney + warningNectar;
                }
                else if (honey < LOW_LEVEL_WARNING) return report + warningHoney;
                else if (nectar < LOW_LEVEL_WARNING) return report + warningNectar;
                else return report;
            }
        }

        public static void ConvertNectarToHoney(float amount)
        {
            if (amount > nectar)
            {
                honey += nectar * NECTAR_CONVERSION_RATIO;
                nectar = 0;
            }
            else
            {
                honey += amount * NECTAR_CONVERSION_RATIO;
                nectar -= amount;
            }
        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount < honey)
            {
                honey -= amount;
                return true;
            }
            else return false;
        }

        public static void CollectNectar(float amount)
        {
            if (amount > 0) nectar += amount;
        }
    }
}
