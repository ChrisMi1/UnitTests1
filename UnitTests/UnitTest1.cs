using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HRLib;
using static HRLib.HRLib;
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


        [TestMethod]
        public void TestMethod5()
        {
            bool failed = false;
            HRLib.HRLib hr = new HRLib.HRLib();
            Employee emp = new Employee("example1", "2102615476", "6975367829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1));
            Employee emp1 = new Employee("example2", "2102615476", "6975367829", new DateTime(1999, 5, 9), new DateTime(2021, 1, 1));
            Employee emp2 = new Employee("example3", "2102615476", "6975367829", new DateTime(2001, 5, 9), new DateTime(2019, 1, 1));
            Employee emp3 = new Employee("example4", "2102615476", "6975367829", new DateTime(1995, 5, 9), new DateTime(2017, 1, 1));
            Employee emp4 = new Employee("example5", "2102615476", "6975367829", new DateTime(1994, 5, 9), new DateTime(2016, 1, 1));

            Object[,] testCases =
            {
                {1,emp,27,4},
                {2,emp1,25,3},
                {3,emp2,23,5},
                {4,emp3,29,7},
                {5,emp4,30,8}
            };
     
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                
                try
                {
                    int Age = 0;
                    int YearsOfExperience = 0;
                    hr.InfoEmployee((Employee)testCases[i, 1], ref Age, ref YearsOfExperience);
                    Assert.AreEqual((int)testCases[i, 2], Age);
                    Assert.AreEqual((int)testCases[i, 3], YearsOfExperience);
                }
                catch (Exception e)
                {
                    failed = true;
                    Console.WriteLine("The test failed is : {0} and a hint is {1}", (int)testCases[i, 0],  e.Message);
                }
            }

            if (failed == true) Assert.Fail();
        }

        [TestMethod]
        public void TestMethod6()
        {
            bool failed = false;
            HRLib.HRLib hr = new HRLib.HRLib(); 
            Employee[] emp = new Employee[] {new Employee("example1", "2102615476", "6975367829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1)),
                                             new Employee("example2", "2105625476", "6980468796", new DateTime(2001, 8, 3), new DateTime(2023, 1, 1)),
                                             new Employee("example3", "2209893944", "6978934829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1)),
                                             new Employee("example4", "2102915476", "6975367829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1))};
            
            Employee[] emp1 = new Employee[] {new Employee("example5","2402615476", "6975367829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1)),
                                             new Employee("example6", "2505625476", "6980468796", new DateTime(2001, 8, 3), new DateTime(2023, 1, 1)),
                                             new Employee("example7", "2609893944", "6978934829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1)),
                                             new Employee("example8", "2802915476", "6975367829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1))};

            Employee[] emp2 = new Employee[] {new Employee("example5","4566432335", "6975367829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1)),
                                             new Employee("example6", "2102984722", "6980468796", new DateTime(2001, 8, 3), new DateTime(2023, 1, 1)),
                                             new Employee("example7", "2101321233", "6978934829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1)),
                                             new Employee("example8", "2105756756", "6975367829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1))};

            Employee[] emp3 = new Employee[] {new Employee("example9", "2102132312", "6975367829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1)),
                                             new Employee("example10", "2102984722", "6980468796", new DateTime(2001, 8, 3), new DateTime(2023, 1, 1)),
                                             new Employee("example11", "2101321233", "6978934829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1)),
                                             new Employee("example12", "2105756756", "6975367829", new DateTime(1997, 5, 9), new DateTime(2020, 1, 1))};

            Object[,] testCases =
            {
                {1,emp,3},
                {2,emp1,0},
                {3,emp2,3},
                {4,emp3,4}
            };
            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                try
                {
                    Assert.AreEqual((int)testCases[i, 2], hr.LiveInAthens((Employee[])testCases[i, 1]));
                }
                catch (Exception ex)
                {
                    failed = true;
                    Console.WriteLine("The test failed is : {0} and a hint is {1}",(int)testCases[i,0], ex.Message);
                }

                
            }
            if (failed == true) Assert.Fail();
        }
    }
}
