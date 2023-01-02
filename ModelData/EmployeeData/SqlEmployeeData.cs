using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Helpers;
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
            _employee.businessId = (Guid)employee.businessId;
            _employee.firstName= employee.firstName;
            _employee.lastName= employee.lastName;
            _employee.birthdate= (DateTime)employee.birthdate;
            _employee.username= employee.username;
            _employee.password= employee.password;
            _employee.shiftId= (Guid)employee.shiftId;
            _employee.id = Guid.NewGuid();
            _employee.permissions = new List<Permission>();
            foreach(Guid permissionId in employee.permissionIds)
            {
                Permission p = context.Permissions.Find(permissionId);
                if(p != null)
                {
                    _employee.permissions.Add(p);
                }
            }
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
            existing.businessId = (Guid)employee.businessId;
            existing.firstName = employee.firstName;
            existing.lastName = employee.lastName;
            existing.birthdate = (DateTime)employee.birthdate;
            existing.username = employee.username;
            existing.password = employee.password;
            existing.shiftId = (Guid)employee.shiftId;
            List<Permission> permissions = new List<Permission>();
            foreach(Guid permissionId in employee.permissionIds)
            {
                Permission p = context.Permissions.Find(permissionId);
                if(p != null)
                {
                    permissions.Add(p);
                }
            }
            existing.permissions = permissions; 
            context.Employees.Update(existing);
            context.SaveChanges();
            return existing;
        }

        public Employee PatchEmployee(Guid id, EmployeeDTO customer)
        {
            var existing = context.Employees.Find(id);
            if (existing != null)
            {
                existing = EntityHelper.PatchEntity<Employee>(existing, customer);
                context.Employees.Update(existing);
                context.SaveChanges();
                return existing;
            }
            else
            {
                return null;
            }
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
