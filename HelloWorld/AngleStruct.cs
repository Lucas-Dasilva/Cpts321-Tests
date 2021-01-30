//-----------------------------------------------------------------------
// Name:"Lucas Da Silva">
// Class: Cpts_321
// Date: 1/29/2021
//-----------------------------------------------------------------------

namespace HelloWorld
{
    using System;

    public struct AngleStruct
    {
        private double angleRadians; // angle in radians

        public AngleStruct(double angleRadians)
        {
            this.angleRadians = angleRadians;
        }

        public double AngleDegrees // PROPERTY – angle in degrees
        {
            get { return this.angleRadians * 180.0 / Math.PI; }
            set { this.angleRadians = value / 180.0 * Math.PI; }
        }
    }
}
