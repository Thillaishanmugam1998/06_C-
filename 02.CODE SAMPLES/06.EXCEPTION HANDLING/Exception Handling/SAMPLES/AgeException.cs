using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPLES
{
    public class AgeException: Exception
    {
        public override string Message => "Enter The Age Greater Than 0";
    }
}
