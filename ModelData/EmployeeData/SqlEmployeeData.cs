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

        public Employee AddEmployee(EmployeeDTO employee)
        {
            Employee _employee = new Employee();
            _employee.businessId = employee.businessId;
            _employee.firstName= employee.firstName;
            _employee.lastName= employee.lastName;
            _employee.birthdate= employee.birthdate;
            _employee.username= employee.username;
            _employee.password= employee.password;
            _employee.shiftId= employee.shiftId;
            context.Employees.Add(_employee);
            context.SaveChanges();
            return _employee;
        }

        public void DeleteEmployee(Guid id)
        {
            context.Employees.Remove(GetEmployee(id));
            context.SaveChanges();
        }

        public Employee EditEmployee(Guid id, EmployeeDTO employee)
        {
            var existing = context.Employees.Find(id);
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
