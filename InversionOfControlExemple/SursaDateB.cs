using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlExemple
{
    public class SursaDateB : ISursaDeDate
    {
        List<Persoana> persoaneBD;

        public SursaDateB()
        {
            persoaneBD = new List<Persoana>();
        }

        public void add(Persoana persoana)
        {
            persoaneBD.Add(persoana);
        }

        public IList<Persoana> readAll()
        {
            return persoaneBD;
        }


        public IList<Persoana> readByName(string name)
        {
            return persoaneBD.Where(p => p.Nume == name).ToList<Persoana>();
        }
    }
}
