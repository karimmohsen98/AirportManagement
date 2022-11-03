using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        //public static Staff captain = new Staff { PassportNumber = "1", FirstName = "captain", LastName = "captain", EmailAddress = "captain.captain@gmail.com", BirthDate = new DateTime(1965, 01, 01), EmploymentDate = new DateTime(1999, 01, 01), Salary = 99999 };
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency)]
        public int Salary { get; set; }

        public override string ToString()
        {
            return "EmploymentDate" + EmploymentDate + "Function" + Function + "Salary" + Salary+ "BirthDate" + BirthDate + "PassPort Number" + PassportNumber + "Email Address" + EmailAddress + "FirstName" + fullName.FirstName + "LastName" + fullName.LastName + "TelNumber" + TelNumber;
        }


            public override void Passengertype()
        {
            Console.WriteLine("im a staff");
        }
       
    }

}
    