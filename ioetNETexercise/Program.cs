using ioetNETexercise.Model;
using ioetNETexercise.Service;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();
        string file;
        if(args.Length == 0) //If a file is specified, it will be used; else, the default file will be used
        {
            Console.WriteLine("No input file was specified. Using the default input file.");
            //file = "data.txt";
            file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "data.txt");
        }
        else
        {
            file = args[0];
            Console.WriteLine($"Using the input file: { file }");
        }

        string[] emps = File.ReadAllLines(file);
        foreach(string emp in emps) //Creates an Employee object per each line in the file
        {
            int index = emp.LastIndexOf('=');
            Employee newEmp = new Employee(emp.Substring(0, index), emp.Substring(index + 1, (emp.Length - index - 1)));
            employees.Add(newEmp); //Adds to the list of employees
        }

        foreach(Employee emp in employees) //Iterating over the list of employees
        {
            EmployeeService employeeService= new EmployeeService();
            //Print report
            Console.WriteLine(emp.name);
            Console.WriteLine($"Total worked hours: {employeeService.CalculateTotalHours(emp.days) }");
            Console.WriteLine($"Total Payment: $ {employeeService.CalculateTotalPayment(emp.days) }");
        }
    }
}