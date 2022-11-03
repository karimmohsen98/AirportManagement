using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.Domain
{

    public class Passenger
    {
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<Ticket> tickets { get; set; }

        public int Id { get; set; }
        
        [Display(Name ="Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
      
        [StringLength(7)]
        public string PassportNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [MinLength(3, ErrorMessage = "Min Length Must Be 3")]
        [MaxLength(25,ErrorMessage = "Max Length Must Be 25")]
        public FullName fullName { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public int TelNumber { get; set; }

        /*public Passenger()
        {
        }

        public Passenger(string emailAddress, string firstName, string lastName) : this(emailAddress, firstName)
        {
            LastName = lastName;
        }
        
        public Passenger(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        */
        public override string ToString()
        {
            return "BirthDate"+BirthDate+"PassPort Number"+PassportNumber+"Email Address"+EmailAddress+"FirstName"+fullName.FirstName+"LastName"+fullName.LastName+"TelNumber"+TelNumber;
        }
        public bool CheckProfile(string FirstName, string LastName) {
            if (this.fullName.FirstName == FirstName && this.fullName.LastName == LastName)
            {
                return true;
            }
            return false;
        }
        public bool CheckProfile(string FirstName, string LastName , string EmailAdress)
        {
            if (this.fullName.FirstName == FirstName && this.fullName.LastName == LastName && this.EmailAddress == EmailAddress)
            {
                return true;
            }
            return false;
        }
      
        public virtual void Passengertype() {
            Console.WriteLine("im a passenger");
         }   

        
             
        
    }

}
