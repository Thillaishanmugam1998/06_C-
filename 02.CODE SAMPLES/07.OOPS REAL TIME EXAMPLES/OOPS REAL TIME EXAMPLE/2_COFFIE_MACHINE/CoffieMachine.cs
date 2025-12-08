using System;
using System.Collections.Generic;
using System.Text;

namespace _2_COFFIE_MACHINE
{
    #region Explanation
    /*
    * Let’s consider another Real-time Example of the coffee machine. 
    * A coffee machine has internal mechanisms and operations (like grinding coffee beans, heating water, etc.) 
    * that the user shouldn’t be concerned about. The user selects the type of coffee they want, and 
    * the machine delivers the final product. Let us see how we can implement this example using the 
    * Encapsulation Principle in C#:
    * */
    #endregion
    public class CoffeeMachine
    {
        private int waterAmount; // in milliliters
        private int beansAmount; // in grams
        private bool isHeated;
        public CoffeeMachine(int water, int beans)
        {
            waterAmount = water;
            beansAmount = beans;
            isHeated = false;
        }
        private void HeatWater()
        {
            if (!isHeated)
            {
                Console.WriteLine("Heating water...");
                isHeated = true;
            }
        }
        private void GrindBeans(int amount)
        {
            if (beansAmount < amount)
            {
                throw new InvalidOperationException("Not enough coffee beans!");
            }
            Console.WriteLine("Grinding coffee beans...");
            beansAmount -= amount;
        }
        // This is the method exposed to the user.
        public void MakeEspresso()
        {
            HeatWater();
            GrindBeans(20); // let's say we need 20 grams of beans for an espresso
            Console.WriteLine("Making Espresso...");
        }
        // Another method exposed to the user.
        public void MakeLatte()
        {
            HeatWater();
            GrindBeans(25); // we need 25 grams of beans for a latte
            Console.WriteLine("Making Latte...");
        }
        public int BeansLeft()
        {
            return beansAmount;
        }
        public int WaterLeft()
        {
            return waterAmount;
        }
    }
}
