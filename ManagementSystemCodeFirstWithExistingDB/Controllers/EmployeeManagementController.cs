using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace ManagementSystemCodeFirstWithExistingDB.Controllers
{
    public class EmployeeManagementController 
    {
        private readonly ManagementSystemContext _context;
        public EmployeeManagementController()
        {
            _context = new ManagementSystemContext();
        }


        //POST:  Create employee passing name, email, phone and roleid
        /*
         Create new employee
        */
        public void CreateNewEmployee(string name,int roleId,string email,int phone)
        {
          

            var employeeContext = _context.Employees;

            //var roleContext = context.Roles.ToList();

            //var roleContextNew = context.Roles.Single(r => r.Id == 1);

            //adding EmployeeDetails context
            var empDetailsContext = _context.EmployeeDetails;

            var newEmpDetails = new EmployeeDetail
            {
                Email = email,
                Phone = phone,

            };


            var newEmp = new Employee
            {
                Name = name,

                //ForeignKey approach
                RoleId = roleId,

                //employee details
                EmployeeDetail = newEmpDetails,


            };

            employeeContext.Add(newEmp);
            _context.SaveChanges();

            Console.WriteLine("New Employee Creation Successful");

        }


        //PUT:  Update existing employee
        /*
         Updating Employee by EmployeeId
        */
        public void UpdateExistingEmployee(int empId, string name, int roleId, string email, int phone)
        {

            var employeeContext = _context.Employees;
            //Updating EmployeeDetails context
            var empDetailsContext = _context.EmployeeDetails;

            var existingEmpDetails = empDetailsContext.Find(empId);
            existingEmpDetails.Email = email;
            existingEmpDetails.Phone = phone;

            //Find Employee by Id
            var existedEmployee = employeeContext.Find(empId);

            existedEmployee.Name = name;
            existedEmployee.RoleId = roleId;
            existedEmployee.EmployeeDetail = existingEmpDetails;

            _context.SaveChanges();

            Console.WriteLine("Updated Employee with ID:" + existedEmployee.Name);
        }


        //Get:  Get the list of all employees

        /*Get list of all employees*/
        public List<Employee> GetAllEmployee()
        {
            var employee = _context.Employees.ToList();

            return employee;
        }

        //Get:  Get details of single employees on the basis if employid

        /*get details of single employee by employeId */
        public string GetEmployeeById(int empId, string empName)
        {

            var empContext = _context.Employees;
            var empDetails = _context.EmployeeDetails;

            /*     var employee =
                     from c in context.Employees
                     where c.EmployeeId == empId
                     select c;

                 */

            var employee =
                empContext
               .Include(c => c.EmployeeDetail)
               .SingleOrDefault(e => e.EmployeeId == empId);


            //foreach (var e in employee)
            //{
            //    //Console.WriteLine(e.Name);
            //    //return e.Name;
            //    empName = e.Name;
            //}

            Console.WriteLine("VVV Employee details Name: {0} ,  Email: {1}", employee.Name, employee.EmployeeDetail.Email);

            empName = employee.Name;
            return empName;

        }



    }
}
