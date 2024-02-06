using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HRLib
{
    public class HRLib
    {
                

        public struct Employee
        {
            public string name;
            public string homePhone;
            public string mobilePhone;
            public DateTime birthDate;
            public DateTime hiringDate; 

            public Employee(string name,string homePhone,string mobilePhone,DateTime birthDate,DateTime hiringDate)
            {
                this.name = name;
                this.homePhone = homePhone;
                this.mobilePhone = mobilePhone;
                this.birthDate = birthDate;
                this.hiringDate = hiringDate; 
            }
        }
        public bool ValidName(string name)
        {
            /*string pattern = "^[A-Za-z A-Za-z]+$";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(name))
            {
                return true;
            }
            else
            {
                return false; 
            }*/

            if(!name.Contains(" ") || name.Any(char.IsDigit) || name.Any(IsSpecialCharacter))
            {
                return false; 
            }
            return true; 
            
        }
        public bool ValidPassword(string password)
        {
            if (password.Length < 12 || !char.IsUpper(password[0]) || !char.IsDigit(password[password.Length-1]) || !password.Any(IsSpecialCharacter) || !password.Any(char.IsLower) || !password.Any(char.IsUpper))
            {
                return false;
            }
            return true; 
        }

        static bool IsSpecialCharacter(char c)
        {
            string specialChars = "!@#$%^&*(),.?\":{}|<>";
            return specialChars.Contains(c);
        }

        public void EncryptPassword(string Password,ref string EncryptedPW)
        {
             foreach(char c in Password)
            {
                int unicode = c;
                unicode += 5;
                EncryptedPW += unicode; 
            }

        }

        public void CheckPhone(string phone,ref int TypePhone,ref string InfoPhone)
        {
            string num = null;
            string num2 = null; 
            if (phone.Length == 10) 
            { 
                num = phone.Substring(0, 2);
                num2 = phone.Substring(0, 3); 
            
                if (num == "21")
                {
                    TypePhone = 0;
                    InfoPhone = "Μητροπολιτική Περιοχή Αθήνας – Πειραιά"; 
                }
                else if (num == "22")
                {
                    TypePhone = 0;
                    InfoPhone = "Ανατολική Στερεά Ελλάδα, Αττική, Νησιά Αιγαίου";
                }
                else if (num == "23")
                {
                    TypePhone = 0;
                    InfoPhone = "Κεντρική Μακεδονία";
                }
                else if (num == "24")
                {
                    TypePhone = 0;
                    InfoPhone = "Θεσσαλία, Δυτική Μακεδονία";
                }
                else if (num == "25")
                {
                    TypePhone = 0;
                    InfoPhone = "Θράκη, Ανατολική Μακεδονία";
                }
                else if (num == "26")
                {
                    TypePhone = 0;
                    InfoPhone = "Ήπειρος, Δυτική Στερεά Ελλάδα, Δυτική Πελοπόννησος, Ιόνια Νησιά";
                }
                else if (num == "27")
                {
                    TypePhone = 0;
                    InfoPhone = "Ανατολική Πελοπόννησος, Κύθηρα";
                }
                else if (num == "28")
                {
                    TypePhone = 0;
                    InfoPhone = "Κρήτη";
                }
                else if (num2 == "690" || num2 == "693" || num2=="699")
                {
                    TypePhone = 1;
                    InfoPhone = "nova";
                }
                else if (num2 == "695" || num2 == "694")
                {
                    TypePhone = 1;
                    InfoPhone = "vodafone";
                }
                else if (num2 == "698" || num2 == "697")
                {
                    TypePhone = 1;
                    InfoPhone = "cosmote";
                }
                else
                {
                    TypePhone = -1;
                    InfoPhone = null;
                }
            }
            else
            {
                TypePhone = -1;
                InfoPhone = null;
            }
        }
        public void InfoEmployee(Employee EmpIX,ref int Age,ref int YearsOfExperience)
        {
            Age = DateTime.Now.Year - EmpIX.birthDate.Year;
            YearsOfExperience = DateTime.Now.Year - EmpIX.hiringDate.Year; 

        }
        public int LiveInAthens(Employee[] empls)
        {
            int total = 0;
            int typePhone = 0;
            string infoPhone = null; 
            foreach(Employee emp in empls)
            {
                CheckPhone(emp.homePhone, ref typePhone, ref infoPhone);
                if (typePhone == 0 && infoPhone.Equals("Μητροπολιτική Περιοχή Αθήνας – Πειραιά"))
                {
                    total += 1; 
                }
            }
            return total; 
        }

        


    }

}



