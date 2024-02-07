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
                    Console.WriteLine("The test case is : {0} with parameter {1} and a hint is {2}/{3}", (int)testCases[i, 0]
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
                    Console.WriteLine("The test failed is : {0} with parameter {1} and a hint is {2}/{3}", (int)testCases[i, 0]
                        , (string)testCases[i, 1], (string)testCases[i, 3],e.Message);
                }
            }
            if (failed == true) Assert.Fail();
        }

        [TestMethod]
        public void TestMethod3()
        {
            bool failed = false;
            
            HRLib.HRLib hr = new HRLib.HRLib();
            Object[,] testCases =
            {
                {1,"Christos@2","721091191101201211161206955"},
                {2,"Kwstas12@3","8012412012110212054556956"},
                {3,"kwstas2","11212412012110212055" },
                {4,"Panos2#","851021151161205540"},
                {5,"KWSTAS","809288897088" },
                {5,"panos23%!","11710211511612055564238"}
            };

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    string encrypted="";
                    hr.EncryptPassword((string)testCases[i, 1], ref encrypted); 

                    Assert.AreEqual((string)testCases[i, 2], encrypted);

                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine("The test failed is : {0} with parameter {1} and a hint is {2} ", (int)testCases[i, 0]
                        , (string)testCases[i, 1], e.Message );
                }
            }
            if (failed == true) Assert.Fail();
        }

        [TestMethod]
        public void TestMethod4()
        {
            bool failed = false;
            HRLib.HRLib hr = new HRLib.HRLib();

            Object[,] testCases =
            {
                {1,"6970556974",1,"cosmote"},
                {2,"9905348659",-1,null },
                {3,"2204865759",0,"Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου" },
                {4,"8549665238",-1,null},
                {5,"2102645876",0,"Μητροπολιτική Περιοχή Αθήνας – Πειραιά"},
                {6,"0000000567",-1,null},
                {7,"6945854916",1,"vodafone" }
            };

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    int TypePhone = -2;
                    string InfoPhone = "";
                    hr.CheckPhone((string)testCases[i, 1],ref TypePhone,ref InfoPhone);
                    Assert.AreEqual((int)testCases[i, 2], TypePhone);
                    Assert.AreEqual((string)testCases[i, 3], InfoPhone);
                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine("The test failed is : {0} with parameter {1} and a hint is {2}", (int)testCases[i, 0]
                        , (string)testCases[i, 1], e.Message);
                }
            }

            if (failed == true) Assert.Fail();
        }
    }
}
