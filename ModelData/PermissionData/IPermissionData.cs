using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.PermissionData
{
    public interface IPermissionData
    {
        List<Permission> GetPermissions();
        Permission GetPermission(Guid id);
        Permission AddPermission(PermissionDTO permission);
        void DeletePermission(Guid id);
        Permission EditPermission(Guid id, PermissionDTO permission);
        Permission PatchPermission(Guid id, PermissionDTO permission);
    }
}
