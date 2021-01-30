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
    public class AngleClass
    {
        private double angleRadians; // angle in radians

        public double AngleDegrees // PROPERTY – angle in degrees
        {
            get { return this.angleRadians * 180.0 / Math.PI; }
            set { this.angleRadians = value / 180.0 * Math.PI; }
        }
    }
}
