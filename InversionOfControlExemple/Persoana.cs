using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlExemple
{
    public class Persoana
    {
        public String Nume {get; set;}
        public String Prenume { get; set; }
        public Int16 Varsta {get; set;}
        
        public string ToString()
        {
            return "Nume: " +  Nume + " Prenume: " + Prenume + " Varsta: " + Varsta.ToString();
        }

    }

}
