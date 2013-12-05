using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PersonsRegistry.Models
{
    [Table("Person")]
    public class Person
    {   [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string profession { get; set; }

        public Person()
        {
            name = "";
            age = 0;
            profession = "";
        }

        public Person(String name, int age, String profession)
        {
            this.name = name;
            this.age = age;
            this.profession = profession;
        }
    }
}