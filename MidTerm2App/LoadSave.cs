//-----------------------------------------------------------------------
// <copyright file="LoadSave.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace MidTerm2App
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// Loads or saves to xml file
    /// </summary>
    public class LoadSave
    {
        /// <summary>
        /// Load data from xml file
        /// </summary>
        /// <param name="shapeFact">The reference to shape factory</param>
        /// <returns>The list of sequences</returns>
        public List<ShapeStructure> LoadFromXML(ShapeFactory shapeFact)
        {
            List<ShapeStructure> structList = new List<ShapeStructure>();
            XmlDocument doc = new XmlDocument();
            string filename = AppDomain.CurrentDomain.BaseDirectory + @"\SavedSequences.xml";
            int c = 0;
            int p = 0;
            int r = 0;
            int sq = 0;
            int t = 0;
            int index = 0;

            // Load the file
            doc.Load(filename);

            // Get all the items that are saved, and store them in a list
            XmlNodeList sequenceList = doc.GetElementsByTagName("sequence");
            XmlNodeList typeList = doc.GetElementsByTagName("type");
            XmlNodeList radiusList = doc.GetElementsByTagName("radius");
            XmlNodeList widthList = doc.GetElementsByTagName("width");
            XmlNodeList lengthList = doc.GetElementsByTagName("length");
            XmlNodeList topList = doc.GetElementsByTagName("topside");
            XmlNodeList botList = doc.GetElementsByTagName("botside");
            XmlNodeList heightList = doc.GetElementsByTagName("height");
            XmlNodeList squareList = doc.GetElementsByTagName("side");
            XmlNodeList penList = doc.GetElementsByTagName("penside");
            XmlNodeList colorList = doc.GetElementsByTagName("color");
            XmlNodeList borderList = doc.GetElementsByTagName("border");

            // Iterate through xml node list, and store each value into the cell
            for (int i = 0; i < sequenceList.Count; i++)
            {
                // Add created sequence as default values to struct list
                ShapeStructure shapeStruct = new ShapeStructure(sequenceList[i].NamespaceURI, shapeFact);

                // Index through each shape in the sequence and change the default values to whatever the saved values are
                foreach (Shape s in shapeStruct.ShapeList)
                {
                    // Check if shape is circle
                    // Check if shape is pentagon
                    // Check if shape is rectangle
                    // Check if shape is square
                    // Check if shape is trapezium
                    if (s is Circle circle)
                    {
                        circle.Radius = Convert.ToDouble(radiusList[c].InnerXml);
                        c++;
                    }
                    else if (s is Pentagon pentagon)
                    {
                        pentagon.SideLength = Convert.ToDouble(penList[p].InnerXml);
                        p++;
                    }
                    else if (s is Rectangle rectangle)
                    {
                        rectangle.Length = Convert.ToDouble(lengthList[r].InnerXml);
                        rectangle.Width = Convert.ToDouble(widthList[r].InnerXml);
                        r++;
                    }
                    else if (s is Square square)
                    {
                        square.LengthSquare = Convert.ToDouble(squareList[sq].InnerXml);
                        sq++;
                    }
                    else if (s is Trapezium trapezium)
                    {
                        trapezium.TopSide = Convert.ToDouble(topList[t].InnerXml);
                        trapezium.BottomSide = Convert.ToDouble(botList[t].InnerXml);
                        trapezium.Height = Convert.ToDouble(heightList[t].InnerXml);
                        t++;
                    }

                    s.Border = borderList[index].InnerXml;
                    s.Color = colorList[index].InnerXml;
                    index++;
                }

                structList.Add(shapeStruct);
            }

            return structList;
        }

        /// <summary>
        /// Save to xml file
        /// </summary>
        /// <param name="structList">Reference to the list of sequences to save</param>
        public void SaveToXML(List<ShapeStructure> structList)
        {
            string filename = AppDomain.CurrentDomain.BaseDirectory + @"\SavedSequences.xml";
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                writer.WriteStartElement("ShapeStruct");

                // Index through shapestruct list, which holds an individual sequence per element
                foreach (ShapeStructure ss in structList)
                {
                    writer.WriteStartElement("sequence", ss.Sequence);

                    // Index thrrough she shape in the sequence
                    foreach (Shape s in ss.ShapeList)
                    {
                        // Check if shape is circle
                        // Check if shape is pentagon
                        // Check if shape is rectangle
                        // Check if shape is square
                        // Check if shape is trapezium
                        if (s is Circle circle)
                        {
                            writer.WriteStartElement("type", circle.Name);
                            writer.WriteElementString("radius", circle.Radius.ToString());
                            writer.WriteElementString("color", circle.Color);
                            writer.WriteElementString("border", circle.Border);
                        }
                        else if (s is Pentagon pentagon)
                        {
                            writer.WriteStartElement("type", pentagon.Name);
                            writer.WriteElementString("penside", pentagon.SideLength.ToString());
                            writer.WriteElementString("color", pentagon.Color);
                            writer.WriteElementString("border", pentagon.Border);
                        }
                        else if (s is Rectangle rectangle)
                        {
                            writer.WriteStartElement("type", rectangle.Name);
                            writer.WriteElementString("length", rectangle.Length.ToString());
                            writer.WriteElementString("width", rectangle.Width.ToString());
                            writer.WriteElementString("color", rectangle.Color);
                            writer.WriteElementString("border", rectangle.Border);
                        }
                        else if (s is Square square)
                        {
                            writer.WriteStartElement("type", square.Name);
                            writer.WriteElementString("side", square.LengthSquare.ToString());
                            writer.WriteElementString("color", square.Color);
                            writer.WriteElementString("border", square.Border);
                        }
                        else if (s is Trapezium trapezoid)
                        {
                            writer.WriteStartElement("type", trapezoid.Name);
                            writer.WriteElementString("topside", trapezoid.TopSide.ToString());
                            writer.WriteElementString("botside", trapezoid.BottomSide.ToString());
                            writer.WriteElementString("height", trapezoid.Height.ToString());
                            writer.WriteElementString("color", trapezoid.Color);
                            writer.WriteElementString("border", trapezoid.Border);
                        }

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }
            }
        }
    }
}