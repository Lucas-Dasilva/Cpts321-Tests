//-----------------------------------------------------------------------
// <copyright file="ShapeStructure.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MidTerm2App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Main class used to save sequences, filter, and create the shapes itself
    /// </summary>
    public class ShapeStructure
    {
        /// <summary>
        /// Describes the sequence input by user, into string array
        /// </summary>
        private string[] sequence;

        /// <summary>
        /// A dictionary, where the key holds the sequence and the value is the list of
        /// shapes created from the sequence.
        /// </summary>
        private Dictionary<string, List<Shape>> shapeDict = new Dictionary<string, List<Shape>>();

        /// <summary>
        /// This will keep track of all the sequences and 
        /// </summary>
        private List<Shape> shapeList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeStructure" /> class.
        /// </summary>
        /// <param name="seq">The sequence given by the user</param>
        public ShapeStructure(string seq)
        {
            // Create a shape list to store all the shapes created from the sequence input
            this.shapeList = new List<Shape>();

            // We want to tokenize string, so we can refer to this.Sequence
            this.TokenizeSequence(seq);
            
            // Create shape factory to handle the expression depending on character
            ShapeFactory factory = new ShapeFactory();

            // Loop through the string array, and call shape factory to create the shapes
            for (int i = 0; i < this.sequence.Length; i++)
            {
                // Add the shape to the list of shapes
                this.shapeList.Add(factory.CreateShape(this.sequence[i], i + 1));
            }

            // Add the sequence and the list of shapes to the dictionary
            this.shapeDict.Add(seq, this.shapeList);
        }

        /// <summary>
        /// Calculates each cumulative area for each sequence input by the user
        /// </summary>
        /// <returns>Cumulative area of the shapes</returns>
        public double CumulativeArea()
        {
            double sumArea = 0.0;
            foreach (Shape s in this.shapeList)
            {
                sumArea += s.Area();
            }

            return sumArea;
        }

        /// <summary>
        /// Tokenizes the string, so that spaces are not being read
        /// </summary>
        /// <param name="seq">the sequence input by the user</param>
        private void TokenizeSequence(string seq)
        {
            
            if (seq.Contains(" "))
            {
                string[] exp = seq.Split(' ');
                this.sequence = exp;
            }
            else
            {
                string exp;
                this.sequence = new string[seq.Length];
                for (int i = 0; i < seq.Length; i ++)
                {
                    exp = seq[i].ToString();
                    this.sequence[i] = exp;
                }
            }

        }
    }
}
