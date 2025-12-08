using System;

namespace SAMPLES
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Voter person = new Voter();
                person.checkAge();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
