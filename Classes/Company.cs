using System;

namespace Classes
{
    public class Company
    {
        // Some readonly properties (let's talk about gets, baby)
        public string Name { get; }
        public DateTime CreatedOn { get; }

        // Create a public property for holding a list of current employees
        public List<Employee> Employees { get; }

        //Create a constructor method thats accepts name of Co and Date it was created
        public Company(string name, DateTime date) 
        {
            Name = name;
            CreatedOn = date;
            Employees = new List<Employee>();
        }

        public void ListEmployees()
        {
            foreach(Employee e in Employees){
                Console.WriteLine($"{e.FirstName} {e.LastName} works for {Name} as {e.Title} since {e.StartDate}.");
            }
        }
    }
}
