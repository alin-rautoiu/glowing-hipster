using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlExemple
{
    public interface ISursaDeDate
    {
        void add(Persoana persoana);
        
        IList<Persoana> readAll();

        //Persoana update(Persoana persoana);

        IList<Persoana> readByName(String name);

        //void delete(Persoana persoana);
    }
}
