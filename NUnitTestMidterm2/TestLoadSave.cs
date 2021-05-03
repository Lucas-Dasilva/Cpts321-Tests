﻿//-----------------------------------------------------------------------
// <copyright file="TestLoadSave.cs" company="Lucas Da Silva 11631988">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace MidTerm2App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    /// <summary>
    /// Tests for Expression Tree
    /// </summary>
    [TestFixture]
    public class TestLoadSave
    {
        /// <summary>
        /// Tests wheter the file we save is equal to the file that we load up
        /// </summary>
        [Test]
        [TestCase("tptp","tptp")]
        [TestCase("csrt","csrp")]
        [TestCase("cctp","tctp")]
        public void TestLoadingAndSaving(string sequence, string sequence2)
        {
            LoadSave ls = new LoadSave();
            
            //List<ShapeStructure> structList = new List<ShapeStructure>();
            ShapeFactory shapeFact = new ShapeFactory();
            ShapeFactory shapeFact2 = new ShapeFactory();
            ShapeStructure struct1 = new ShapeStructure(sequence, shapeFact);
            ShapeStructure struct2 = new ShapeStructure(sequence2, shapeFact2);
            List<ShapeStructure> savedList = new List<ShapeStructure>();
            List<ShapeStructure> loadedList = new List<ShapeStructure>();

            savedList.Add(struct1);
            savedList.Add(struct2);

            ls.SaveToXML(savedList);

            loadedList = ls.LoadFromXML(shapeFact);

            for(int i =0; i < loadedList.Count; i++)
            {
                ScrambledEquals(loadedList[i].ShapeList, savedList[i].ShapeList);
            }
        }

        /// <summary>
        /// Used to compare shapelist property values
        /// </summary>
        /// <param name="list1">first list of shapes</param>
        /// <param name="list2">Second list of shapes</param>
        /// <returns>True if the listt of shapes are equal, false otherwise</returns>
        public static bool ScrambledEquals(List<Shape> list1, List<Shape> list2)
        {
            // Compare each property
            for(int i = 0; i < list1.Count; i++)
            {
                if(list1[i].Area != list2[i].Area)
                {
                    return false;
                }
                if (list1[i].Border != list2[i].Border)
                {
                    return false;
                }
                if (list1[i].Color != list2[i].Color)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

