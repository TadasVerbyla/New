using Point_of_Sale_Lab3.Models;
using System.Reflection;

namespace Point_of_Sale_Lab3.Helpers
{
    public static class EntityHelper
    {
        // Quick and dirty Generic Method to apply not null attribute values from the DTO to the actual entity
        // TODO: needs cleaning, (set Generic parameter on entity too?)
        public static T PatchEntity<T>(object entity, object entityDto)
        {
            PropertyInfo[] props = entityDto.GetType().GetProperties();

            foreach (PropertyInfo property in props)
            {
                string propertyName = property.Name;

                object dtoPropertyValue = property.GetValue(entityDto, null);
                object modelPropertyValue = entity.GetType().GetProperty(propertyName).GetValue(entity, null);

                if (dtoPropertyValue != null)
                {
                    entity.GetType().GetProperty(propertyName).SetValue(entity, dtoPropertyValue);
                }
                else
                {
                    entity.GetType().GetProperty(propertyName).SetValue(entity, modelPropertyValue);
                }
            }

            return (T)entity;
        }
    }
}
