using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.PermissionData
{
    public class SqlPermissionData : IPermissionData
    {
        private PointOfSaleContext context;
        public SqlPermissionData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Permission AddPermission(Permission permission)
        {
            permission.id = Guid.NewGuid();
            context.Permissions.Add(permission);
            context.SaveChanges();
            return permission;
        }

        public void DeletePermission(Guid id)
        {
            context.Permissions.Remove(GetPermission(id));
            context.SaveChanges();
        }

        public Permission EditPermission(Permission permission)
        {
            var existing = context.Permissions.Find(permission.id);
            existing.name = permission.name;
            context.Permissions.Update(existing);
            context.SaveChanges();
            return permission;
        }

        public Permission GetPermission(Guid id)
        {
            return context.Permissions.Find(id);
        }

        public List<Permission> GetPermissions()
        {
            return context.Permissions.ToList();
        }
    }
}
