using System;
using System.Collections.Generic;

delegate bool IsPromotable(Employee emp);

class DelegateExample
{
    public static void Main()
    {
        List<Employee> listEmployee = new List<Employee>();
        listEmployee.Add(new Employee(){Id = 101,Name = "Mary",Salary = 5000,Experience = 5});
        listEmployee.Add(new Employee(){Id = 102,Name = "John",Salary = 6000,Experience = 6});
        listEmployee.Add(new Employee(){Id = 103,Name = "Sam",Salary = 7000,Experience = 7});
        listEmployee.Add(new Employee(){Id = 104,Name = "Mariyam",Salary = 4000,Experience = 4});
      	
      	IsPromotable delIsPromo = new IsPromotable(IsEligibleSalary);
      	Console.WriteLine("On Salary basis : ");
        Employee.PromotedEmployee(listEmployee,delIsPromo);
     		
      	delIsPromo = new IsPromotable(IsEligibleExperience);
      	Console.WriteLine("On Experience basis : ");
        Employee.PromotedEmployee(listEmployee,delIsPromo);
    }
  
  	public static bool IsEligibleSalary(Employee emp)
    {
      if(emp.Salary > 2000)
        return true;
      else
        return false;
    }
  
  	public static bool IsEligibleExperience(Employee emp)
    {
      if(emp.Experience > 5)
        return true;
      else
        return false;
    }
}

class Employee
{
    public int Id{get;set;}
    public string Name{get;set;}
    public int Salary{get;set;}
    public int Experience{get;set;}
    
    public static void PromotedEmployee(List<Employee> employeeList,IsPromotable isEligible)
    {
        foreach(Employee empl in employeeList)
        {
            if(isEligible(empl))
            {
                Console.WriteLine(empl.Name);
            }
        }
    }
}
