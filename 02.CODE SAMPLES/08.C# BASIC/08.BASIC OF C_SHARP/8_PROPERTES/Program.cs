using System;

namespace _9_PROPERTIES_COMPLETE
{
    class Program
    {
        static void Main(string[] args)
        {
            // ===================================================================
            // PROPERTIES IN C#
            //
            // WHY WE USE PROPERTIES?
            // 1) Encapsulation → Protect private fields
            // 2) Validation → Check values before assigning
            // 3) Clean + readable compared to get()/set() methods
            // 4) Control Read or Write access
            // 5) Can compute values dynamically (no extra fields)
            // ===================================================================

            #region FULL PROPERTY (BACKING FIELD + GET/SET)
            Student st = new Student();
            st.Name = "Thillai";       // setter runs
            st.Age = 22;               // setter runs with validation
            Console.WriteLine(st.Name); // getter runs
            Console.WriteLine(st.Age);
            #endregion

            #region AUTO-PROPERTY EXAMPLE
            AutoStudent ast = new AutoStudent();
            ast.Id = 101;              // auto-set
            ast.Course = "C#";         // auto-set
            Console.WriteLine(ast.Id);
            Console.WriteLine(ast.Course);
            #endregion

            #region READ-ONLY PROPERTY EXAMPLE
            Console.WriteLine("Created Date: " + st.CreatedDate);
            #endregion

            #region WRITE-ONLY PROPERTY EXAMPLE
            Salary slip = new Salary();
            slip.Amount = 50000; // Allowed
            // Console.WriteLine(slip.Amount); ❌ ERROR: No getter available
            #endregion

            #region COMPUTED PROPERTY EXAMPLE
            Console.WriteLine("Full Name Info: " + st.FullInfo);
            #endregion

            Console.WriteLine("\nAll property examples executed. Read comments inside code for deep understanding.");
        }
    }


    // =======================================================================
    // FULL PROPERTY (MOST IMPORTANT FOR INTERVIEW)
    // =======================================================================
    class Student
    {
        // BACKING FIELD → Internal storage
        private string _name;
        private int _age;

        // FULL PROPERTY → get + set + validation
        public string Name
        {
            get { return _name; }       // reading
            set { _name = value; }      // writing
        }

        public int Age
        {
            get { return _age; }
            set
            {
                // VALIDATION EXAMPLE:
                if (value < 0)
                    _age = 0;
                else
                    _age = value;
            }
        }

        // READ-ONLY PROPERTY
        public DateTime CreatedDate { get; } = DateTime.Now;

        // COMPUTED PROPERTY (NO FIELD, VALUE CALCULATED)
        public string FullInfo
        {
            get
            {
                return $"Name: {_name}, Age: {_age}";
            }
        }
    }


    // =======================================================================
    // AUTO-PROPERTY (MOST USED IN REAL PROJECTS)
    // =======================================================================
    class AutoStudent
    {
        public int Id { get; set; }         // Auto getter + setter
        public string Course { get; set; }  // No validation required
    }


    // =======================================================================
    // WRITE-ONLY PROPERTY (RARE BUT INTERVIEW LOVES THIS)
    // =======================================================================
    class Salary
    {
        private int _amount;

        // WRITE-ONLY → Only setter, no getter
        public int Amount
        {
            set { _amount = value; }
        }
    }

}
