using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HRLib; 
namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool failed = false;
            string msg = "The name must have 1 space between first name and last name";
            string msg1 = "The name must not have symmbols or digits "; 
            HRLib.HRLib hr = new HRLib.HRLib();
            Object[,] testCases=
            {
                {1,"Kwstas Palaiologou",true,msg+msg1},
                {2,"Panos Dionysopoulos2",false,msg+msg1 },
                {3,"Christos Maltezos#",false,msg+msg1 },
                {4,"Christos",false,msg+msg1 },
                {5,"panos Dionysopoulos",true,msg+msg1}
            };

            for(int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testCases[i, 2], hr.ValidName((string)testCases[i, 1]));

                }catch(Exception e)
                {
                    failed = true;
                    Console.WriteLine("The test failed is : {0} with parameter {1} and a hint is {2}/{3}", (int)testCases[i, 0]
                        , (string)testCases[i, 1], (string)testCases[i, 3],e.Message); 
                }
            }
            if (failed == true) Assert.Fail(); 
        }

        [TestMethod]
        public void TestMethod2()
        {
            bool failed = false;
            string msg = "\n Ο κωδικός πρεπει να είναι μεγαλύτερος απο 12 χαρακτήρες\nΟ κωδικός πρέπει να ξεκινάει με κεφαλαίο γράμμα και τελείωνει με αριθμό\nΠρέπει να υπάρχουν κεφαλαία και μικρά γράμματα\n Πρέπει να υπάρχει τουλάχιστον ένα σύμβολο και ένα νούμερο\n Τα γράμματα πρέπει να ειναι λατινικά";
            HRLib.HRLib hr = new HRLib.HRLib();
            Object[,] testCases =
            {
                {1,"KwstasPappa12@3",true,msg},
                {2,"kwstas2",false,msg },
                {3,"KWSTAS",false,msg },
                {4,"Christos2#",false,msg},
                {5,"christos#",false,msg},
                {6,"ChristosGate12!2",true,msg},
                {7,"kwstas#2",false,msg }
            };

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((bool)testCases[i, 2], hr.ValidPassword((string)testCases[i, 1]));

                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine("The test failed is : {0} with parameter {1} and a hint is {2}", (int)testCases[i, 0]
                        , (string)testCases[i, 1], (string)testCases[i, 3]);
                }
            }
            if (failed == true) Assert.Fail();
        }
    }
}
