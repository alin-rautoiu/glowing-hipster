using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlExemple
{
    public class DispecerA
    {
        ISursaDeDate sursa;

        public DispecerA(ISursaDeDate sursa)
        {
            this.sursa = sursa;
        }

        public Persoana CreatePerson()
        {
            Persoana persoana = new Persoana();
            
            Console.WriteLine("Nume: ");
            persoana.Nume = Console.ReadLine();
            
            Console.WriteLine("Prenume: ");
            persoana.Prenume = Console.ReadLine();
            
            Console.WriteLine("Varsa: ");
            var varsta = Console.ReadLine();
            try
            {
                persoana.Varsta = Int16.Parse(varsta);
            }
            catch (Exception)
            {
                Console.WriteLine("Ai scris gresit!");
                throw;
            }
            
            return persoana;
        }

        public void AddPerson()
        {
            sursa.add(CreatePerson());
        }
        
        public void AddPerson(Persoana persoana)
        {
            sursa.add(persoana);
        }
        
        public IList<Persoana> Read()
        {
            return sursa.readAll();
        }

        public IList<Persoana> ReadByName(string name)
        {
            return sursa.readByName(name);
        }
    }
}
