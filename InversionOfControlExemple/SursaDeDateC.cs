using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlExemple
{
    public class SursaDeDateC : ISursaDeDate
    {
        List<Persoana> persoaneXML;

        public SursaDeDateC()
        {
            persoaneXML = new List<Persoana>();
        }

        public void add(Persoana persoana)
        {
            persoaneXML.Add(persoana);
        }

        public IList<Persoana> readAll()
        {
            return persoaneXML;
        }

        public IList<Persoana> readByName(string name)
        {
            return persoaneXML.Where(p => p.Nume == name).ToList<Persoana>();
        }
    }
}
