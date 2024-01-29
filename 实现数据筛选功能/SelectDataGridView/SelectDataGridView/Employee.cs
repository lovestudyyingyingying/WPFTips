using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectDataGridView
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int Age { get; set; }

        public static Employee FakeOne() => employeeFaker.Generate();
        public static IEnumerable<Employee> FakeMany(int count)=>employeeFaker.Generate(count);

        private static readonly Faker<Employee> employeeFaker = new Faker<Employee>().RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName).RuleFor(x => x.Age, x => x.Random.Int(20, 40));
    }
}
