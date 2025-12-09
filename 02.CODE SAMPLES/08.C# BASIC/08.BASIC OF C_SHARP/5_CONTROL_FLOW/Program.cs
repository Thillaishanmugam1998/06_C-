using System;

namespace _5_CONTROL_FLOW
{
    class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------
            // CONTROL FLOW STATEMENTS IN C#
            // Control flow decides:
            //  - WHICH code will execute (if / else / switch)
            //  - HOW MANY TIMES code will execute (loops)
            //
            // MAIN KEYWORDS (GOOD FOR INTERVIEW):
            //  if, else, switch, case, default
            //  while, do, for
            //  break, continue, goto
            // -------------------------------------------------------------------

            #region IF-ELSE STATEMENTS IN C#
            // Used to execute code based on TRUE/FALSE conditions.

            int age = 20;

            // Simple IF:
            if (age >= 18)
            {
                // This block executes only when condition is TRUE
                // Example: Allow user to vote
                bool canVote = true;
            }

            // IF-ELSE:
            bool isAdult;
            if (age >= 18)
            {
                isAdult = true;    // age is 18 or more
            }
            else
            {
                isAdult = false;   // age is below 18
            }

            // IF - ELSE IF - ELSE (decision chain)
            int temperature = 30;
            string weatherStatus;

            if (temperature < 10)
            {
                weatherStatus = "Cold";
            }
            else if (temperature < 25)
            {
                weatherStatus = "Normal";
            }
            else
            {
                weatherStatus = "Hot";
            }

            // INTERVIEW TIP:
            // Use if-else when you are checking ranges or complex conditions.
            #endregion

            #region SWITCH STATEMENTS IN C#
            // SWITCH is used when you are checking ONE value against MANY cases.

            int dayNumber = 3;  // 1 = Monday, 2 = Tuesday, ...

            string dayName;

            switch (dayNumber)
            {
                case 1:
                    dayName = "Monday";
                    break; // Exit switch after match

                case 2:
                    dayName = "Tuesday";
                    break;

                case 3:
                    dayName = "Wednesday";
                    break;

                case 4:
                    dayName = "Thursday";
                    break;

                case 5:
                    dayName = "Friday";
                    break;

                case 6:
                    dayName = "Saturday";
                    break;

                case 7:
                    dayName = "Sunday";
                    break;

                default:
                    dayName = "Invalid day";
                    break;
            }

            // INTERVIEW TIP:
            // - Use switch for fixed values (enums, menu options, small int values).
            // - 'break' is required in each case to avoid falling through.
            #endregion

            #region LOOPS IN C# (OVERVIEW)
            // Loops are used to REPEAT code.
            //
            // while       → Repeat WHILE condition is TRUE (check first, then run)
            // do-while    → Run at least once, THEN check condition
            // for         → Best when you know how many times to loop
            //
            // break       → Exit the loop immediately
            // continue    → Skip the current iteration, go to next
            #endregion

            #region WHILE LOOP IN C#
            // WHILE: Check condition first, then run the block.

            int whileCounter = 1;
            int whileSum = 0;

            // Add numbers from 1 to 5 using while loop
            while (whileCounter <= 5)
            {
                whileSum = whileSum + whileCounter;  // accumulate sum
                whileCounter++;                      // move to next number
            }

            // After loop: whileSum = 1+2+3+4+5 = 15
            #endregion

            #region DO-WHILE LOOP IN C#
            // DO-WHILE: Run ONCE for sure, then check condition.
            // Useful when you want to show a menu at least once.

            int doWhileCounter = 1;
            int doWhileSum = 0;

            do
            {
                doWhileSum = doWhileSum + doWhileCounter;
                doWhileCounter++;
            } while (doWhileCounter <= 5);

            // Same result as while loop: doWhileSum = 15
            // MAIN DIFFERENCE: do-while executes the block AT LEAST ONE TIME,
            // even if condition is false at first.
            #endregion

            #region FOR LOOP IN C#
            // FOR LOOP: Best when you know HOW MANY TIMES to repeat.

            int forSum = 0;

            // Add numbers from 1 to 5 using for loop
            for (int i = 1; i <= 5; i++)
            {
                forSum = forSum + i;
            }
            // After loop: forSum = 15

            // INTERVIEW TIP:
            // for (init; condition; increment)
            //  - init: runs once at start
            //  - condition: checked every loop
            //  - increment: runs after each iteration
            #endregion

            #region BREAK STATEMENT IN C#
            // BREAK: Used to EXIT from loop or switch immediately.

            int[] numbers = { 1, 3, 5, 7, 9, 11 };
            int searchValue = 7;
            bool found = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == searchValue)
                {
                    found = true;
                    // We found the value; no need to continue loop
                    break;   // Exit the for loop
                }
            }

            // INTERVIEW TIP:
            // - break exits only the INNER MOST loop or switch.
            #endregion

            #region CONTINUE STATEMENT IN C#
            // CONTINUE: Skip to the next iteration of the loop.

            int sumOfOddNumbers = 0;

            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    // If even, skip the rest of this loop and go to next i
                    continue;
                }

                // This code will run only for ODD numbers
                sumOfOddNumbers = sumOfOddNumbers + i;
            }

            // After loop: sumOfOddNumbers = 1+3+5+7+9 = 25

            // INTERVIEW TIP:
            // Use 'continue' when you want to IGNORE some cases but not stop the loop.
            #endregion

            #region GOTO STATEMENT IN C#
            // GOTO: Jumps to a labeled statement.
            // NOTE: In real projects, 'goto' is avoided (makes code hard to read),
            // but it is useful to understand for interviews.

            int gotoCounter = 0;

        StartLabel:  // This is a label

            gotoCounter++;

            if (gotoCounter < 3)
            {
                // Jump back to label until gotoCounter becomes 3
                goto StartLabel;
            }

            // After this, gotoCounter will be 3

            // INTERVIEW TIP:
            // - goto can be used to jump inside the same method.
            // - Better to use loops and functions instead of goto in production code.
            #endregion

            Console.WriteLine("Control flow examples executed (study comments inside code).");
        }
    }
}
