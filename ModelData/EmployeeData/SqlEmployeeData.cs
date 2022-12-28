using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private PointOfSaleContext context;
        public SqlEmployeeData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.id = Guid.NewGuid();
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Guid id)
        {
            context.Employees.Remove(GetEmployee(id));
            context.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {
            var existing = context.Employees.Find(employee.id);
            existing.businessId = employee.businessId;
            existing.firstName = employee.firstName;
            existing.lastName = employee.lastName;
            existing.birthdate = employee.birthdate;
            existing.username = employee.username;
            existing.password = employee.password;
            existing.shiftId = employee.shiftId;
            context.Employees.Update(existing);
            context.SaveChanges();
            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            return context.Employees.Find(id);
        }

        public List<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }
    }
}
