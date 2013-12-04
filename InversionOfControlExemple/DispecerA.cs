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
        IPersonInitialization personInitialization;

        public DispecerA(ISursaDeDate sursa, IPersonInitialization personInitialization)
        {
            this.sursa = sursa;
            this.personInitialization = personInitialization;
        }

        public void AddPerson()
        {
            sursa.add(personInitialization.CreatePerson());
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

    public interface IPersonInitialization
    {
        Persoana CreatePerson();
    }

    public class PersonInitialization : IPersonInitialization
    {
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
    }
}
