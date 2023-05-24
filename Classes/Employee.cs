using System;

namespace Classes
{
    public class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public DateTime StartDate { get; }

        public Employee(string first, string last, string title, DateTime date) 
        {
            FirstName = first;
            LastName = last;
            Title = title;
            StartDate = date;
        }

    }
}
