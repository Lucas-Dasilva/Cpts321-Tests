//-----------------------------------------------------------------------
// <copyright file="TestPrintStatements.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MidTerm2App
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    /// <summary>
    /// Tests for print statements
    /// </summary>
    [TestFixture]
    public class TestPrintStatements
    {
        /// <summary>
        /// Tests Print statements
        /// </summary>
        [Test]
        public void TestPrint()
        {
            ShapeFactory fact = new ShapeFactory();
            Stack<ShapeStructure> sequenceStack = new Stack<ShapeStructure>();

            ShapeStructure shapeStruct = new ShapeStructure("c s c r", fact);
            sequenceStack.Push(shapeStruct);

            shapeStruct = new ShapeStructure("c c r r", fact);
            sequenceStack.Push(shapeStruct);

            shapeStruct = new ShapeStructure("r r c r", fact);
            sequenceStack.Push(shapeStruct);
            
            shapeStruct = new ShapeStructure("s s s s c r", fact);
            sequenceStack.Push(shapeStruct);

            shapeStruct = new ShapeStructure("s c s s r r", fact);
            sequenceStack.Push(shapeStruct);
            
            shapeStruct = new ShapeStructure("c c c c", fact);
            sequenceStack.Push(shapeStruct);

            // Print the last item
            shapeStruct.PrintSequenceInfo();

            // Scroll through stack of structs
            foreach (var item in sequenceStack)
            {
                item.PrintSequenceInfo();
            }
        }
    }
}