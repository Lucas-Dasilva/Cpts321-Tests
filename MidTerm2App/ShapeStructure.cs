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
        private string[] tokenSequence;

        /// <summary>
        /// This will keep track of all the sequences and 
        /// </summary>
        private List<Shape> shapeList;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeStructure" /> class.
        /// </summary>
        /// <param name="seq">The sequence given by the user</param>
        /// <param name="factory">The shape factory reference needed, to get default values</param>
        public ShapeStructure(string seq, ShapeFactory factory)
        {
            // Create a shape list to store all the shapes created from the sequence input
            this.shapeList = new List<Shape>();

            // We want to tokenize string, so we can refer to this.Sequence
            this.TokenizeSequence(seq);
            
            // Loop through the string array, and call shape factory to create the shapes
            for (int i = 0; i < this.tokenSequence.Length; i++)
            {
                // Add the shape to the list of shapes
                this.shapeList.Add(factory.CreateShape(this.tokenSequence[i], i + 1));
            }

            // Set the original sequence
            this.Sequence = seq;

            // Set the sum of the areas
            this.SumOfArea = this.CumulativeArea();
            
            // Set the sum of the areas
            this.ShapeList = this.shapeList;
        }

        /// <summary>
        /// Gets or sets the list of shapes
        /// </summary>
        public List<Shape> ShapeList { get; set; }

        /// <summary>
        /// Gets or sets the sum of areas
        /// </summary>
        public string Sequence { get; set; }

        /// <summary>
        /// Gets or sets the sum of areas
        /// </summary>
        public double SumOfArea { get; set; }

        /// <summary>
        /// Prints the last sequence and all of it's shapes info.
        /// </summary>
        public void PrintSequenceInfo()
        {
            Console.WriteLine($"Sequence: \"{this.Sequence}\"\n");
            foreach (Shape s in this.shapeList)
            {
                s.Info();
            }
        }

        /// <summary>
        /// Calculates each cumulative area for each sequence input by the user
        /// </summary>
        /// <returns>Cumulative area of the shapes</returns>
        private double CumulativeArea()
        {
            double sumArea = 0.0;

            // Calculate the cumulative area of the shape list
            foreach (Shape s in this.shapeList)
            {
                sumArea += s.Area();
            }

            return Math.Round(sumArea, 2);
        }

        /// <summary>
        /// Tokenizes the string, so that spaces are not being read
        /// </summary>
        /// <param name="seq">the sequence input by the user</param>
        private void TokenizeSequence(string seq)
        {
            // Check if string is in right format
            // else tokenize without spaces
            if (seq.Contains(" "))
            {
                string[] exp = seq.Split(' ');
                this.tokenSequence = exp;
            }
            else
            {
                string exp;
                this.tokenSequence = new string[seq.Length];
                for (int i = 0; i < seq.Length; i++)
                {
                    exp = seq[i].ToString();
                    this.tokenSequence[i] = exp;
                }
            }
        }
    }
}
