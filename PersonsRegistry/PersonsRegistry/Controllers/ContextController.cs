using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonsRegistry.Controllers
{
    public class ContextController : DbContext
    {
        //
        // GET: /Context/

        public DbSet<PersonsRegistry.Models.Person> Persons { get; set; }        
    }
}
