using System;

namespace CarSimulator
{
    class Engine
    {
        private float engineCapacity;
        private float fuelTankCap;
        private float defaultFuelTankCap = 5;

        public float EngineCapacity
        {
            get
            {
                return engineCapacity;
            }

            set
            {
                engineCapacity = value;
            }
        }
        public float Fuel;
        public float FuelTankCap
        {
            get
            {
                return fuelTankCap;
            }

            set
            {
                fuelTankCap = value;
            }
        }

        public Engine() { }

        public Engine(float EngineCapacity, float Fuel)
        {
            defaultFuelTankCap = FuelTankCap;
            this.EngineCapacity = EngineCapacity;
            this.Fuel = Fuel;
        }

        public Engine(float EngineCapacity, float Fuel, float FuelTankCap)
        {
            this.EngineCapacity = EngineCapacity;
            this.Fuel = Fuel;
            this.FuelTankCap = FuelTankCap;
        }

        public static void literToMPG()
        {
            Console.Clear();
            Console.WriteLine("Enter how much fuel your car burn in liters per 100km: ");
            float burningKm = float.Parse(Console.ReadLine());
            float result = 235.2F / burningKm;
            Console.WriteLine("Your car is driving {0} mpg.", result);
            Console.WriteLine("Enter a key to go back to menu.");
            Console.ReadKey();
            Program.Menu();
        }

        public static void galonToLKM()
        {
            Console.Clear();
            Console.WriteLine("Enter estimated MPG of your car: ");
            float burninMPG = float.Parse(Console.ReadLine());
            float result = 235.2F / burninMPG;
            Console.WriteLine("Your car burns {0} liters/100km.", result);
            Console.WriteLine("Enter a key to go back to menu.");
            Console.ReadKey();
            Program.Menu();
        }

        public float Work(float fuel)
        {
            float burnRatePerKm = FuelTankCap * 4 / 100;
            Fuel -= burnRatePerKm;
            return Fuel;
        }

        public float Tank()
        {
            Console.WriteLine("Enter the amount of gasoline you want to re-fuel: ");
            float newFuel = float.Parse(Console.ReadLine());
            return newFuel;
        }
    }
}
