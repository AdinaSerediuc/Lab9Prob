using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9Prob
{
    class Employee
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public double Salary { get; set; }
        public Department Department { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Id: {Id}, Salary: {Salary}, Department: {Department.Name}";
        }
    }
