using System;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Collections.Generic;

using Exercicio2.Entities;

namespace Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double salaryBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> employees = new List<Employee>();

            using(StreamReader sr = File.OpenText(path))
            {
                while(!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                    employees.Add(new Employee(name, email, salary));
                }

                var emails = employees.Where(p => p.Salary > salaryBase)
                .Select(p => p.Email);

                Console.WriteLine("Email of people whose salary is more than " 
                + salaryBase.ToString("F2", CultureInfo.InvariantCulture) + ": ");

                foreach(var email in emails)
                {
                    Console.WriteLine(email);
                }
                
                var sum = employees.Where(p => p.Name[0] == 'M')
                .Select(p => p.Salary)
                .Sum();

                Console.WriteLine("Sum of salary of people whose name starts with 'M': "
                + sum.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}
