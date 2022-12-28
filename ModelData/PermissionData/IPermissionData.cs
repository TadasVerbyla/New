using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.PermissionData
{
    public interface IPermissionData
    {
        List<Permission> GetPermissions();
        Permission GetPermission(Guid id);
        Permission AddPermission(Permission permission);
        void DeletePermission(Guid id);
        Permission EditPermission(Permission permission);
    }
}
