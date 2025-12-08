/*Encapsulation Real-time Example in C#: Car’s speedometer
Consider another real-world example: a car’s speedometer and related components. 
A car’s speedometer displays the current speed to the driver. Internally, 
this speed is determined by several factors and calculations related to wheel rotations and gear ratios, 
but the driver only needs to see the final speed value. 
They don’t need to know (and often don’t want to know) the complex calculations and mechanisms involved.
Let us see how we can implement this example using the Encapsulation Principle in C#:
*/

using System;

namespace SPEEDOMETER
{
    //Testing Encapsulation Principle
    public class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Drive();  // Outputs: Current speed: 8.4 m/s
            myCar.Drive();  // Outputs: Current speed: 16.8 m/s
            Console.Read();
        }
    }
}
