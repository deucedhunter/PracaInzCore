using KimiNoGakko.Models;
using System;
using System.Linq;

namespace KimiNoGakko.Data
{
    public class DbInitializer
    {
        public static void Seed(SchoolContext context)
        {

            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }

            var studnets = new Student[]
            {
                    new Student
                    {
                        FirstMidName = "Kacper", LastName = "Zieliński", BirthDate = DateTime.Parse("2001-12-09"),
                        Pesel = "79110874438", GudrdianPhoneNumber = "48054202987"
                    },
                    new Student
                    {
                        FirstMidName = "Natalia", LastName = "Piątek", BirthDate = DateTime.Parse("2001-09-21"),
                        Pesel = "80121036346", GudrdianPhoneNumber = "48663152241"
                    },
                    new Student
                    {
                        FirstMidName = "Julia", LastName = "Kowalczyk", BirthDate = DateTime.Parse("2001-03-06"),
                        Pesel = "60121262316", GudrdianPhoneNumber = "48273042084"
                    },
                    new Student
                    {
                        FirstMidName = "Maja", LastName = "Kamińska", BirthDate = DateTime.Parse("2001-01-18"),
                        Pesel = "81051393264", GudrdianPhoneNumber = "48949479768"
                    },
                    new Student
                    {
                        FirstMidName = "Lidia", LastName = "Król", BirthDate = DateTime.Parse("2001-11-18"),
                        Pesel = "55061312643", GudrdianPhoneNumber = "48241666891"
                    },
                    new Student
                    {
                        FirstMidName = "Jan", LastName = "Wróblewski", BirthDate = DateTime.Parse("2001-08-06"),
                        Pesel = "78060196425", GudrdianPhoneNumber = "48447842051"
                    },
                    new Student
                    {
                        FirstMidName = "Kacper", LastName = "Wróbel", BirthDate = DateTime.Parse("2001-07-03"),
                        Pesel = "76041765864", GudrdianPhoneNumber = "48810757734"
                    },
            };

            foreach (Student studnet in studnets)
            {
                context.Students.Add(studnet);
            }

            context.SaveChanges();

            var instructors = new Instructor[]
            {
                    new Instructor
                    {
                        FirstMidName = "Damian", LastName = "Król", BirthDate = DateTime.Parse("2001-07-03"),
                        HireDate = DateTime.Parse("2001-07-03"), Pesel = "50041765824"
                    },
                    new Instructor
                    {
                        FirstMidName = "Marta", LastName = "Kowalska", BirthDate = DateTime.Parse("2001-07-03"),
                        HireDate = DateTime.Parse("2001-07-03"), Pesel = "64041765884"
                    },
                    new Instructor
                    {
                        FirstMidName = "Julia", LastName = "Kaźmierczak", BirthDate = DateTime.Parse("2001-07-03"),
                        HireDate = DateTime.Parse("2001-07-03"), Pesel = "73041765816"
                    },
            };

            foreach (Instructor instructor in instructors)
            {
                context.Instructors.Add(instructor);
            }

            context.SaveChanges();

        }
    }
}