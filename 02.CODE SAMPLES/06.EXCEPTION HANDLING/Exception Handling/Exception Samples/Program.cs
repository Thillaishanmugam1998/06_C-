using System;

namespace Exception_Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            //#region --- 01. CLASS - 1 ---
            //Class1 obj1 = new Class1();
            ////obj1.WithException();    //With exception with out handling 
            //obj1.WithExceptionHandling();  //with exception with handling 
            //obj1.ExceptionHandling(); //with exception and handling and exception property
            //#endregion

            #region --- 02. CLASS - 2 ---
            Class2 obj2 = new Class2();
            obj2.MultipleCatchBlock();
            #endregion

        }
    }
}
