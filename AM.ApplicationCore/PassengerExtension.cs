using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore
{
    public static class PassengerExtension 
    {
        public static void UpperFullName(this Passenger p) //methode d'extension on ajoute this to the parametre
        {
            string fN = p.fullName.FirstName[0].ToString().ToUpper()+p.fullName.FirstName.Substring(1);
            string lN = p.fullName.LastName[0].ToString().ToUpper() + p.fullName.LastName.Substring(1);

            Console.WriteLine(fN+" "+ lN);
                     
        
        }
    }
}
