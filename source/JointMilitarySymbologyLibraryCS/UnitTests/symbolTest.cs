﻿using JointMilitarySymbologyLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    
    
    /// <summary>
    ///This is a test class for symbolTest and is intended
    ///to contain all symbolTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SymbolTest
    {

        private static Librarian _librarian;
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            _librarian = new Librarian(string.Empty);
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for legacySIDC
        ///</summary>
        [TestMethod()]
        public void LegacySIDCTest_MakeThenGet()
        {
            Symbol target = _librarian.MakeSymbol("2525C", "SFAPM----------");
            string expected = "SFAPM----------";
            string actual = target.LegacySIDC;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for legacySIDC
        ///</summary>
        [TestMethod()]
        public void LegacySIDCTest_ConversionFrom2525D_Air()
        {
            Symbol target = _librarian.MakeSymbol(1003010000, 1100000000);
            string expected = "SFAPM----------";
            string actual = target.LegacySIDC;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for legacySIDC
        ///</summary>
        [TestMethod()]
        public void LegacySIDCTest_ConversionFrom2525D_Space()
        {
            Symbol target = _librarian.MakeSymbol(1003050000, 1107000000);
            string expected = "SFPPS----------";
            string actual = target.LegacySIDC;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for legacySIDC
        ///</summary>
        [TestMethod()]
        public void LegacySIDCTest_ConversionFrom2525D_Sea()
        {
            Symbol target = _librarian.MakeSymbol(1004301000, 1301040000);
            string expected = "SNSANI---------";
            string actual = target.LegacySIDC;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for sidc
        ///</summary>
        [TestMethod()]
        public void SIDCTest_MakeThenGet()
        {
            Symbol target = _librarian.MakeSymbol(1003010000, 1100000000);
            UInt32 expectedPartA = 1003010000;
            UInt32 expectedPartB = 1100000000;
            SIDC actual = target.SIDC;
            Assert.AreEqual(expectedPartA, actual.PartAUInt);
            Assert.AreEqual(expectedPartB, actual.PartBUInt);
        }

        /// <summary>
        ///A test for sidc
        ///</summary>
        [TestMethod()]
        public void SIDCTest_ConversionFrom2525C_Air()
        {
            Symbol target = _librarian.MakeSymbol("2525C", "SFAPM----------");
            UInt32 expectedPartA = 1003010000;
            UInt32 expectedPartB = 1100000000;
            SIDC actual = target.SIDC;
            Assert.AreEqual(expectedPartA, actual.PartAUInt);
            Assert.AreEqual(expectedPartB, actual.PartBUInt);
        }

        /// <summary>
        ///A test for sidc
        ///</summary>
        [TestMethod()]
        public void SIDCTest_ConversionFrom2525C_Space()
        {
            Symbol target = _librarian.MakeSymbol("2525C", "SFPPS----------");
            UInt32 expectedPartA = 1003050000;
            UInt32 expectedPartB = 1107000000;
            SIDC actual = target.SIDC;
            Assert.AreEqual(expectedPartA, actual.PartAUInt);
            Assert.AreEqual(expectedPartB, actual.PartBUInt);
        }

        /// <summary>
        ///A test for sidc
        ///</summary>
        [TestMethod()]
        public void SIDCTest_ConversionFrom2525C_Sea()
        {
            Symbol target = _librarian.MakeSymbol("2525C", "SJSPCUS--------");
            UInt32 expectedPartA = 1015300000;
            UInt32 expectedPartB = 1207000300;
            SIDC actual = target.SIDC;
            Assert.AreEqual(expectedPartA, actual.PartAUInt);
            Assert.AreEqual(expectedPartB, actual.PartBUInt);
        }

        /// <summary>
        ///A test for bad/invalid sidc
        ///</summary>
        [TestMethod()]
        public void SIDCTest_Invalid2525CCode()
        {
            Symbol target = _librarian.MakeSymbol("2525C", "XXXXXXXXXXXXXXX");
            Assert.IsNull(target);
        }

        /// <summary>
        ///A test for bad/invalid sidc
        ///</summary>
        [TestMethod()]
        public void SIDCTest_Invalid2525DCode()
        {
            Symbol target = _librarian.MakeSymbol(1111111111, 1111111111);
            Assert.IsNull(target);
        }
    }
}
