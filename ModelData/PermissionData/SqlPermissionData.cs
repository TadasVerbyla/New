﻿using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Helpers;
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

        public Permission AddPermission(PermissionDTO permission)
        {
            Permission _permission = new Permission();
            _permission.name = permission.name;
            _permission.id = Guid.NewGuid();
            context.Permissions.Add(_permission);
            context.SaveChanges();
            return _permission;
        }

        public void DeletePermission(Guid id)
        {
            context.Permissions.Remove(GetPermission(id));
            context.SaveChanges();
        }

        public Permission EditPermission(Guid id, PermissionDTO permission)
        {
            var existing = context.Permissions.Find(id);
            existing.name = permission.name;
            context.Permissions.Update(existing);
            context.SaveChanges();
            return existing;
        }

        public Permission PatchPermission(Guid id, PermissionDTO customer)
        {
            var existing = context.Permissions.Find(id);
            if (existing != null)
            {
                existing = EntityHelper.PatchEntity<Permission>(existing, customer);
                context.Permissions.Update(existing);
                context.SaveChanges();
                return existing;
            }
            else
            {
                return null;
            }
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
