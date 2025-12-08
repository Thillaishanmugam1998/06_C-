using System;

namespace _2_COFFIE_MACHINE
{
    class Program
    {
        static void Main(string[] args)
        {
            CoffeeMachine myMachine = new CoffeeMachine(1000, 100);  // Initialize with 1000 ml of water and 100 grams of beans
            myMachine.MakeEspresso();  // Outputs: Heating water... Grinding coffee beans... Making Espresso...
            Console.WriteLine($"Beans left: {myMachine.BeansLeft()} grams");  // Outputs: Beans left: 80 grams
            Console.Read();
        }
    }
}
