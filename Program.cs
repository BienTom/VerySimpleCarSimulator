using System;
using System.Threading;

namespace CarSimulator
{
    class Program
    {
        static float FloatExceptionCatch(string message)
        {
            float result;

            while (true)
            {
                string input;
                Console.WriteLine(message);

                try
                {
                    input = Console.ReadLine();
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine("No operational memory.\nProgram will be terminated.");
                    throw e;
                }
                try
                {
                    result = float.Parse(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong number format entered.");
                }
                Console.WriteLine("\aWrong data entered, please enter the data again.");
            }
            return result;
        }

        static uint UintExceptionCatch(string message)
        {
            uint result;

            while (true)
            {
                string input;
                Console.WriteLine(message);

                try
                {
                    input = Console.ReadLine();
                }
                catch (OutOfMemoryException e)
                {
                    Console.WriteLine("No operational memory.\nProgram will be terminated.");
                    throw e;
                }
                try
                {
                    result = uint.Parse(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Number in wrong format entered, please enter an integer.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The entered number is outside the permissible range.");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("The end of the stream reached.");
                }
                Console.WriteLine("\aWrong data, please enter again.");
            }
            return result;
        }

        static string EmptyStringException(string message)
        {
            string input;
            Console.WriteLine(message);
            input = Console.ReadLine();
            while (input == String.Empty)
            {
                Console.WriteLine("You entered nothing, please try again.");
                input = Console.ReadLine();
            }

            return input;
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("-Car simulator- \n");
            Console.WriteLine("1. MPG<->LiterPerKm Conventer");
            Console.WriteLine("2. LiterPerKm Conventer<->MPG");
            Console.WriteLine("3. Driving Simulator");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Please choose: ");
            string answer = Console.ReadLine();
            int _answer;

            while (!Int32.TryParse(answer, out _answer))
            {
                Console.WriteLine("Wrong format of entry, please try again.");
                Thread.Sleep(2000);
                Menu();
            }
            
                switch (_answer)
                {
                    case 1:
                        Engine.galonToLKM();
                        break;
                    case 2:
                        Engine.literToMPG();
                        break;
                    case 3:
                        CarSim();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Number out of range, please choose from menu.");
                        Thread.Sleep(2000);
                        Menu();
                        break;
                }
        }

        public static void CarSim()
        {
            Console.Clear();
            string brand = EmptyStringException("Enter car brand: ");
            string model = EmptyStringException("Enter car model: ");
            float engineCap = FloatExceptionCatch("Enter engine capacity: ");
            uint tankCap = UintExceptionCatch("Enter tank capacity: ");
            float fuel = FloatExceptionCatch("Enter amount of fuel: ");
            float distance = FloatExceptionCatch("Enter the number of kilometers to drive: ");

            Engine e1 = new Engine(engineCap, fuel, tankCap);
            Car c1 = new Car(brand, model, e1);

            c1.Drive(distance);
        }

        static void Main(string[] args)
        {
            Menu();
            CarSim();
        }

    }
}

