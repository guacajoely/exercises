using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of a company. Name it whatever you like.

            DateTime currentDateTime = DateTime.Now;
            var MyFirstCompany = new Company("Joel's Company", currentDateTime);

            // Create three employees
            var EmployeeOne = new Employee("John", "Smith", "Project Manager", currentDateTime);
            var EmployeeTwo = new Employee("Sarah", "Baker", "IT Consultant", currentDateTime);
            var EmployeeThree = new Employee("Tim", "Stevens", "Receptionist", currentDateTime);

            // Assign the employees to the company
            MyFirstCompany.Employees.Add(EmployeeOne);
            MyFirstCompany.Employees.Add(EmployeeTwo);
            MyFirstCompany.Employees.Add(EmployeeThree);

            /*
                Iterate the company's employee list and generate the
                simple report shown above
            */

            MyFirstCompany.ListEmployees();

       
        }
    }
}