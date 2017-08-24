using System;
using System.Threading;

namespace CarSimulator
{
    class Car
    {
        private string brand;
        private string model;
        Engine e = new Engine();

        public string Brand
        {
            get
            {
                return brand;
            }

            set
            {
                brand = value;
            }
        }
        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }

        public Car(string Brand, string Model, float EngineCapacity, float Fuel, float FuelTankCap)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.e.EngineCapacity = EngineCapacity;
            this.e.Fuel = Fuel;
            //this.fuelTankCap = FuelTankCap;
        }

        public Car(string Brand, string Model, float EngineCapacity, float Fuel)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.e.EngineCapacity = EngineCapacity;
            this.e.Fuel = Fuel;
        }

        public Car(string Brand, string Model, Engine engine)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.e = engine;
        }

        public void Drive(float distance)
        {
            for (int i = 1; i <= distance; i++)
            {
                for (uint j = 0; j <= i + 2; j++)
                    Console.Write(" ");
                Console.WriteLine("  /---|_");
                for (uint j = 0; j <= i; j++)
                    Console.Write(" ");
                Console.WriteLine("... o----o");
                Thread.Sleep(100);
                Console.Clear();
                e.Work(this.e.Fuel);

                if (e.Fuel <= 0)
                {
                    Console.WriteLine("Do you want to re-fuel? (Y/N)");
                    string answer = Console.ReadLine();
                    string Answer = answer.ToUpper();
                    if (Answer == "Y")
                    {
                        e.Fuel = e.Tank();
                    }
                    else if (Answer == "N")
                    {
                        Console.WriteLine("Ok...Thanks for the ride! Click a button to go back to menu.");
                        Console.ReadKey();
                        Program.Menu();
                    }
                    else
                    {
                        Console.WriteLine("Wrong answer...please enter Y or N.");
                    }
                }
                Console.WriteLine("{0} liters of fuel left.", this.e.Fuel.ToString("0.00"));
            }
            Console.WriteLine("I'm on destination point, {0} liters of fuel left.\nClick a button to go back to menu.", this.e.Fuel.ToString("0.00"));
            Console.ReadKey();
            Program.Menu();
        }
    }
}

