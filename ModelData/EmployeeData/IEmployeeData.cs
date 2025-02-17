﻿using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(Guid id);
        Employee AddEmployee(EmployeeDTO employee);
        void DeleteEmployee(Guid id);
        Employee EditEmployee(Guid id, EmployeeDTO employee);
        Employee PatchEmployee(Guid id, EmployeeDTO employee);
    }
}
