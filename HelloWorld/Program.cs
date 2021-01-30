//-----------------------------------------------------------------------
// Name:"Lucas Da Silva">
// Class: Cpts_321
// Date: 1/29/2021
//-----------------------------------------------------------------------

namespace HelloWorld
{
    using System;

    // This class calls all the functions necessary for exercise 1
    public class Program
    {
        // Main function, start of program
        public static void Main(string[] args)
        {
            // Task 1: Show scenario where struct is passed by value and class is by reference
            Console.WriteLine("\nStart of Task1: ");
            AngleStruct ang_struct = new AngleStruct(23.4);
            AngleClass ang_class = new AngleClass();
            ang_class.AngleDegrees = 23.4;

            // Printing angle degrees before change
            Console.WriteLine("Angle Struct before change: " + ang_struct.AngleDegrees);
            Console.WriteLine("Angle Class before change: " + ang_class.AngleDegrees);

            // Calling changing functions
            ChangeAngleStruct(ang_struct);
            ChangeAngleClass(ang_class);

            // Printing angle degrees after change
            Console.WriteLine("Angle Struct After change: " + ang_struct.AngleDegrees);
            Console.WriteLine("Angle Class After change: " + ang_class.AngleDegrees);


            // Task 2: Create Basic MEssageClass

            // (1). Show Hello world by ref and value
            Console.WriteLine("\nStart of Task2: ");
            BasicMessageClass msg = new BasicMessageClass();
            string s1 = "hello with set message by reference";
            msg.SetMessage("hello with set message by value"); // pass by value
            msg.ShowMessageConsole();

            msg.SetMessage(s1); // pass by ref
            msg.ShowMessageConsole();

            // (2). Show Hello world on screen
            Console.WriteLine("Hello World!");

            // (3). Show Hello world on file
            string s2 = "Hello from file, passed by ref";
            System.IO.File.WriteAllText("test1.txt", s2); // file located in bin/debug/..
        }

        // Change struct by ref
        public static void ChangeAngleStruct(AngleStruct ang_struct)
        {
            ang_struct.AngleDegrees = 0.0;
        }

        // Change class by ref
        public static void ChangeAngleClass(AngleClass ang_class)
        {
            ang_class.AngleDegrees = 0.0;
        }
    }
}
