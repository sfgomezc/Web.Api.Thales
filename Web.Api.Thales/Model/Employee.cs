using System;
using System.Collections.Generic;

namespace Web.Api.Thales
{
    public class EmployeesResult
    {
        public string status { get; set; }
        public IEnumerable<Employee> data { get; set; }
    }

    public class EmployeeResult
    {
        public string status { get; set; }
        public Employee data { get; set; }
    }

    public class Employee
    {
        public int id { get; set; }

        public string employee_name { get; set; }

        public decimal employee_salary { get; set; }

        public int employee_age { get; set; }

        public string profile_image { get; set; }
    }
}
