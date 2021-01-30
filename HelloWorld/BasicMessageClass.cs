//-----------------------------------------------------------------------
// Name:"Lucas Da Silva">
// Class: Cpts_321
// Date: 1/29/2021
//-----------------------------------------------------------------------

namespace HelloWorld
{
    using System;

    /// <summary>
    /// This class writes helloworld.
    /// </summary>
    public class BasicMessageClass
    {
        private string message = "(default message)";

        // Writes out in console the message
        public void ShowMessageConsole()
        {
            Console.WriteLine(this.message); // Console.WriteLine(this.message); // Expression-bodied member
        }

        // PROPERTY : Acts a lot like a field to code outside of the class, but it is actually an accessor method;
        public string GetMessage() { return this.message; } // equivalent to: get => message;

        // PROPERTY : Acts a lot like a field to code outside of the class, but it is actually an accessor method;
        public void SetMessage(string value) { this.message = value; } // equivalent to: set => message = value;
    }
}
