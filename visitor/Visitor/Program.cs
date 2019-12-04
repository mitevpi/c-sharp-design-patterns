using System;
using System.Collections.Generic;

/// <summary>
/// This code demonstrates the Visitor pattern in which two 
/// objects traverse a list of Employees and performs the same 
/// operation on each Employee. The two visitor objects 
/// define different operations -- one adjusts vacation days and 
/// the other income.
/// </summary>
namespace Visitor.Demonstration
{
    /// <summary>
    /// Visitor Design Pattern.
    /// </summary>
    class Client
    {
        static void Main()
        {
            // Setup employee collection
            Employees e = new Employees();
            e.Attach(new Clerk());
            e.Attach(new Director());
            e.Attach(new President());

            // Employees are 'visited'
            e.Accept(new IncomeVisitor());
            e.Accept(new VacationVisitor());

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Visitor' interface
    /// </summary>
    interface IVisitor
    {
        void Visit(Element element);
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    class IncomeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Console.WriteLine("{0} {1}'s new income: {2:C}",
                employee.GetType().Name, employee.Name,
                employee.Income);
        }
    }

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 3 extra vacation days
            employee.VacationDays += 3;
            Console.WriteLine("{0} {1}'s new vacation days: {2}",
                employee.GetType().Name, employee.Name,
                employee.VacationDays);
        }
    }

    /// <summary>
    /// The 'Element' abstract class
    /// </summary>
    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    /// <summary>
    /// The 'ConcreteElement' class
    /// </summary>
    class Employee : Element
    {
        // Constructor
        public Employee(string name, double income,
            int vacationDays)
        {
            Name = name;
            Income = income;
            VacationDays = vacationDays;
        }

        // Gets or sets the name
        public string Name { get; set; }

        // Gets or sets income
        public double Income { get; set; }

        // Gets or sets number of vacation days
        public int VacationDays { get; set; }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// The 'ObjectStructure' class
    /// </summary>
    class Employees
    {
        private List<Employee> _employees = new List<Employee>();

        public void Attach(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            _employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Employee e in _employees)
            {
                e.Accept(visitor);
            }

            Console.WriteLine();
        }
    }

    // Three employee types

    class Clerk : Employee
    {
        // Constructor
        public Clerk()
            : base("Harry", 25000.0, 14)
        {
        }
    }

    class Director : Employee
    {
        // Constructor
        public Director()
            : base("Edward", 35000.0, 16)
        {
        }
    }

    class President : Employee
    {
        // Constructor
        public President()
            : base("Damond", 45000.0, 21)
        {
        }
    }
}