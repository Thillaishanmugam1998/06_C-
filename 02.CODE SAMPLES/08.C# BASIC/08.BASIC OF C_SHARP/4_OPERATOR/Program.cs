using System;

namespace _4_OPERATOR
{
    class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------
            // OPERATORS IN C# (Study Notes Inside Code)
            // -------------------------------------------------------------------

            #region 1. ARITHMETIC OPERATORS (+ - * / %)
            int a = 10, b = 3;
            int add = a + b; //13
            int sub = a - b; // 7
            int mul = a * b; //30
            int div = a / b; //3
            int mod = a % b; //1
            #endregion

            #region 2. RELATIONAL OPERATORS (< <= > >= == !=)
            bool r1 = a < b; //false
            bool r2 = a > b; //true
            bool r3 = a == b; //false
            bool r4 = a != b; //true
            #endregion

            #region 3. LOGICAL OPERATORS (&& || !)
            bool x = true, y = false;
            bool andResult = x && y; //false
            bool orResult = x || y; //true
            bool notResult = !x; //false
            #endregion

            #region 4. BITWISE OPERATORS (& | ^ << >> ~)
            int n1 = 5;    // binary 0101
            int n2 = 3;    // binary 0011

            int bitAnd = n1 & n2;     // 0001 → 1
            int bitOr = n1 | n2;      // 0111 → 7
            int bitXor = n1 ^ n2;     // 0110 → 6
            int leftShift = n1 << 1;  // 1010 → 10
            int rightShift = n1 >> 1; // 0010 → 2
            int bitNot = ~n1;         // Two's complement → -6
            #endregion

            #region BITWISE AND / OR / XOR – MANUAL STEP BY STEP
            // n1 = 5 →  0101
            // n2 = 3 →  0011

            // AND (&) : Only 1 & 1 = 1
            // 0101
            // 0011
            // ----
            // 0001 → 1

            // OR (|) : Any 1 gives 1
            // 0101
            // 0011
            // ----
            // 0111 → 7

            // XOR (^) : Different bits = 1
            // 0101
            // 0011
            // ----
            // 0110 → 6
            #endregion

            #region TWO'S COMPLEMENT EXPLANATION (~ OPERATOR)
            // bitNot = ~5
            //
            // Step 1: Write 5 in binary (32-bit)
            // 00000000 00000000 00000000 00000101
            //
            // Step 2: Flip all bits (~)
            // 11111111 11111111 11111111 11111010
            //
            // Step 3: To find decimal → Two’s Complement:
            //    a) Invert bits again
            //       00000000 00000000 00000000 00000101
            //    b) Add 1
            //       00000000 00000000 00000000 00000110 → 6
            //
            // Since original flipped result starts with 1 (negative sign):
            // Final answer = -6
            #endregion

            #region 4.1 LEFT & RIGHT SHIFT – BIG NUMBER EXAMPLE (12345)
            int num = 12345;

            // LEFT SHIFT = multiply
            int left1 = num << 1;  // 12345 * 2 = 24690
            int left2 = num << 2;  // 12345 * 4 = 49380
            int left3 = num << 3;  // 12345 * 8 = 98760

            // RIGHT SHIFT = divide
            int right1 = num >> 1; // 12345 / 2 = 6172
            int right2 = num >> 2; // 12345 / 4 = 3086
            int right3 = num >> 3; // 12345 / 8 = 1543
            #endregion

            #region 5. ASSIGNMENT OPERATORS
            int value = 10;
            value += 5;
            value -= 3;
            value *= 2;
            value /= 4;
            value %= 5;
            #endregion

            #region 6. UNARY OPERATORS (++ --)
            int num2 = 10;
            num2++;
            num2--;
            int pre = ++num2;
            int post = num2++;
            #endregion

            #region 7. TERNARY OPERATOR (?:)
            int age = 18;
            string result = (age >= 18) ? "Adult" : "Minor";
            #endregion

            Console.WriteLine("Operator examples executed successfully!");
        }
    }
}
