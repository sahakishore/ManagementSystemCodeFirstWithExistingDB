using System;
using ManagementSystemCodeFirstWithExistingDB.Controllers;

namespace ManagementSystemCodeFirstWithExistingDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //taking input from consumer

            var empDetailsPost = new
            {
                name = "New Empolyee add Test 9",
                roleId = 1,
                email = "test8@gmail.com",
                phone = 923456789,

            };

            var empDetailsPut = new
            {
                empId = 12,
                name = "Edited Empolyee add Test 12",
                roleId = 1,
                email = "changed12@gmail.com",
                phone = 123456789,

            };

            var empDetailsGet = new
            {
                empId = 8,
                empName = "",
            };


            var employeeContext = new EmployeeManagementController();
           


            //creating new Employee
            employeeContext.CreateNewEmployee(empDetailsPost.name, empDetailsPost.roleId, empDetailsPost.email, empDetailsPost.phone);

            /*get details of single employee by employeId */
            //calling GetEmployeeById method
           

            string empDetailsById = employeeContext.GetEmployeeById(empDetailsGet.empId, empDetailsGet.empName);
            Console.WriteLine("Employee details:" + empDetailsById);

            


            //Update Existing Employee
            employeeContext.UpdateExistingEmployee(empDetailsPut.empId, empDetailsPut.name, empDetailsPut.roleId, empDetailsPut.email, empDetailsPut.phone);



            /*Get list of all Employee */
            //calling GetAllEmployee method

            var allEmployee = employeeContext.GetAllEmployee();


            Console.WriteLine("All Employees:");
            foreach (var e in allEmployee)
            {
                Console.WriteLine(e.Name);
            }


        }

    }
}
