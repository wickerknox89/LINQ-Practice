using LINQ_Practice;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

List<Employee> _lstEmployees = new List<Employee>()
{
    new Employee(){Id=1, Username="Anil", Salary=5000, Age=21, Department="HR"},
    new Employee(){Id=2, Username="Sunil", Salary=6000, Age=42, Department="QA"},
    new Employee(){Id=3, Username="Lokesh", Salary=5000, Age=60, Department="HR"},
    new Employee(){Id=4, Username="Anil", Salary=7000, Age=21, Department="Client Support"},
    new Employee(){Id=5, Username="Ajay", Salary=20000, Age=56, Department="DEV"},
    new Employee(){Id=6, Username="Alok", Salary=90000, Age=89, Department="QA"},
    new Employee(){Id=7, Username="Krish", Salary=30000, Age=56, Department="DEV"},
    new Employee(){Id=8, Username="Ramesh", Salary=40000, Age=32, Department="Management"},
    new Employee(){Id=9, Username="Alok", Salary=7000, Age=56, Department="DEV"},
    new Employee(){Id=10, Username="Jaqueline", Salary=9000, Age=64, Department="DEV"},
    new Employee(){Id=11, Username="Alok", Salary=35000, Age=42, Department="Management"},
    new Employee(){Id=12, Username="Krish", Salary=85000, Age=21, Department="Client Support"},
    new Employee(){Id=13, Username="Alok", Salary=6000, Age=32, Department="HR"},
    new Employee(){Id=14, Username="Eshaan", Salary=5000, Age=21, Department="QA"}, 
    new Employee(){Id=15, Username="Alok", Salary=85000, Age=62, Department="DEV" }
};

IEnumerable<Employee> emp = _lstEmployees.Where(x => x.Salary >= 60000);
foreach (var item in emp)
{
    Console.WriteLine("{0} - {1} - {2} - {3} - {4}", item.Id, item.Username, item.Age, item.Department, item.Salary);
}
Console.WriteLine("\n\n");

foreach (var item in emp)
{
    Console.WriteLine($"Hello Mr.{item.Username} (Id: {item.Id}) Age: {item.Age}, Salary: {item.Salary} Department: {item.Department}");
}



