using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
//using System.EntityF
//using System.Web.Script.Serialization;

namespace ManagementSystemCodeFirstWithExistingDB
{
    class Program
    {
        
       
      
        static void Main(string[] args)
        {
            //create DbContext
            //var context = new ManagementSystemContext();



            /*Get list of all Employee */



            /*get details of single employee by employeId */

            /*   var employee =
                   from c in context.Employees
                   where c.EmployeeId == 1
                   select c;

               foreach(var e in employee)
               {
                   Console.WriteLine(e.Name);
               }*/


            //creating new Employee
            //CreateNewEmployee();
            

            //calling GetEmployeeById method
            string empDetails = GetEmployeeById( 7, "");
            Console.WriteLine("Employee details:" + empDetails);


            //calling GetAllEmployee method
            var allEmp = GetAllEmployee();


            Console.WriteLine("All Employees:");
            foreach (var e in allEmp)
            {
                Console.WriteLine(e.Name);
            }


            



        }


        /*get details of single employee by employeId */
        public static string GetEmployeeById( int empId, string empName)
        {
          
            var context = new ManagementSystemContext();

            /*var employee =
                from c in context.Employees
                where c.EmployeeId == empId
                select c;*/

            var employee =
                context.Employees
                .SingleOrDefault(a => a.EmployeeId == empId);


            //foreach (var e in employee)
            //{
            //    //Console.WriteLine(e.Name);
            //    //return e.Name;
            //    empName = e.Name;
            //}

            //Console.WriteLine("VVV Employee details Name:{0}   Email: {1}" + employee.Name, employee.EmployeeDetail.Email);

            empName = employee.Name;
            return empName;

           

        }



        /*Get list of all employees*/
        public static List<Employee> GetAllEmployee()
        {

            var context = new ManagementSystemContext();

            var employee = context.Employees.ToList();




            //foreach (var e in employee)
            //{
            //    Console.WriteLine(e.Name);
            //    //return e.Name;
            //    //empName = e.Name;
            //}


            //return empName;
            return employee;


        }


        /*
         Create new employee
         */

        public static void CreateNewEmployee()
        {

            var context = new ManagementSystemContext();

            var employeeContext = context.Employees;



            //var roleContext = context.Roles.ToList();

            //here id comes as input , assign employee with a single role
            //var roleContextNew = context.Roles.Single(r => r.Id == 1);

            //adding EmployeeDetails context
            var empDetailsContext = context.EmployeeDetails;

            var newEmpDetails = new EmployeeDetail
            {
                Email = "test2@gmail.com",
                Phone = 123456789,

            };
            //empDetailsContext.Add




            var newEmp = new Employee
            {
                Name = "New Empolyee add Test 2",

                //ForeignKey approach
                RoleId = 2,

               //Role = roleContextNew,

                //employee details
                EmployeeDetail = newEmpDetails,


            };

            employeeContext.Add(newEmp);
            context.SaveChanges();
            //await _context.SaveChangesAsync();

            Console.WriteLine("New Employee Creation Successful");

        }


    }
}
