using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Moq;
namespace InversionOfControlExemple
{
    class Program
    {
        static void Main(string[] args)
        {
            DispecerA dispA;
          
            /*dispA = new DispecerA(sursB);
            dispA.AddPerson();
            dispA.AddPerson();
            foreach (var pers in dispA.Read())
            {
                String result = String.Format("Nume: {0} Prenume: {1}, Varsta: {2}", 
                    pers.Nume, pers.Prenume, pers.Varsta);
                Console.WriteLine(result);
            }*/

            dispA = new DispecerA(GetSursaDate(GetContainer()));
            dispA.AddPerson();
            dispA.AddPerson();
            foreach (var pers in dispA.Read())
            {
                String result = String.Format("Nume: {0} Prenume: {1}, Varsta: {2}",
                    pers.Nume, pers.Prenume, pers.Varsta);
                Console.WriteLine(result);
            }

        }

        private static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SursaDeDateC>().As<ISursaDeDate>();
            var container = builder.Build();

            return container;
        }

        private static ISursaDeDate GetSursaDate(IContainer container)
        {
            ISursaDeDate sursaDeDate;

            using(var scope = container.BeginLifetimeScope())
            {
                sursaDeDate = scope.Resolve<ISursaDeDate>();
            }
            
            return sursaDeDate;
        }
    }
}
