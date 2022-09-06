using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Throw;

namespace MKasperczyk.Learning.InterestingPackages.Throw
{
    public class ThrowExamples
    {
        public void Main()
        {
            string name = "Michal";

            // longer:
            if (string.Equals(name, "Michal"))
                throw new ArgumentException("String should not be equal to 'Michal'");
            // shorter:
            name.Throw().IfEquals("Michal"); // Same thing, the same message body



            // string
            name.Throw("CustomMessage").IfEquals("Michal");
            name.Throw(() => new Exception()).IfEquals("Michal");

            name.Throw(() => new Exception())
                    .IfEquals("Michal") // many conditions
                    .IfLongerThan(2)
                    .IfContains("test")
                .Throw("AnotherException") // throw secound exception for other conditions
                    .IfNotStartsWith("W");


            // If Null
            name.ThrowIfNull();



            // Collection 
            var collection = new List<string>();
            collection.Throw()
                .IfEmpty()
                .IfContains("test");

            // Many others like https statuses, files itd. itp. 

            // Extensions
            Student student = new () { Id = 1, Name = "Johny", Degree = 1 };
            student.Throw()
                .IfHasLowerDegreeThen2();
        }
    }

    public static class ValidatableExtensions
    {
        public static ref readonly Validatable<Student> IfHasLowerDegreeThen2(this in Validatable<Student> validatable)
        {
            if(validatable.Value.Degree <= 2)
            {
                throw new Exception("Degree lower then 2"); // Of course better to throw own exception, not this one.
            }

            return ref validatable;
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Degree { get; set; }
    }
}
