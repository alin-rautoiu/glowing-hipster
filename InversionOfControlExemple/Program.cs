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
            IContainer container = GetContainer();
            ISursaDeDate sursa = GetObjectInstance<ISursaDeDate>(container);
            IPersonInitialization personInitialization = GetObjectInstance<IPersonInitialization>(container);

          
            /*dispA = new DispecerA(sursB);
            dispA.AddPerson();
            dispA.AddPerson();
            foreach (var pers in dispA.Read())
            {
                String result = String.Format("Nume: {0} Prenume: {1}, Varsta: {2}", 
                    pers.Nume, pers.Prenume, pers.Varsta);
                Console.WriteLine(result);
            }*/

            

            dispA = new DispecerA(sursa, personInitialization);
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
            builder.RegisterType<SursaDateB>().As<ISursaDeDate>();
            builder.RegisterType<PersonInitialization>().As<IPersonInitialization>();
            var container = builder.Build();

            return container;
        }


        //o mizerie veche
        //private static ISursaDeDate GetSursaDate(IContainer container)
        //{
        //    ISursaDeDate sursaDeDate;

        //    using(var scope = container.BeginLifetimeScope())
        //    {
        //        sursaDeDate = scope.Resolve<ISursaDeDate>();
        //    }
            
        //    return sursaDeDate;
        //}

        private static T GetObjectInstance<T>(IContainer container)
        {
            T resultObject;
            using (var scope = container.BeginLifetimeScope())
            {
                resultObject = scope.Resolve<T>();
            }

            return resultObject;
        }
    }
}
