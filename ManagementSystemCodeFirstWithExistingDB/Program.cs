using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
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

            //calling GetEmployeeById method
            string empDetails = GetEmployeeById( 1, "");
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

            var employee =
                from c in context.Employees
                where c.EmployeeId == empId
                select c;


            foreach (var e in employee)
            {
                //Console.WriteLine(e.Name);
                //return e.Name;
                empName = e.Name;
            }

            return empName;
            /*var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(employee);
            
            return serializedResult;*/

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
         Creat new employee
         */


    }
}
