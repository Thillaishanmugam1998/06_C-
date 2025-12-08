using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPLES
{
    public class Voter
    {
        public void checkAge()
        {
            try
            {
                Console.WriteLine("Enter the age:");
                int age = int.Parse(Console.ReadLine());

                if(age>0)
                {
                    Console.WriteLine("You are eligible");
                }
                else
                {
                    throw new AgeException();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }



        }
    }
}
