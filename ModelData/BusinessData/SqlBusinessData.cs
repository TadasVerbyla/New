using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Helpers;
using Point_of_Sale_Lab3.Models;
using System.Reflection;

namespace Point_of_Sale_Lab3.ModelData.BusinessData
{
    public class SqlBusinessData : IBusinessData
    {
        private PointOfSaleContext context;
        public SqlBusinessData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Business AddBusiness(BusinessDTO business)
        {
            Business _business = new Business();
            _business.accountNumber = business.accountNumber;
            _business.address = business.address;
            _business.closing = (DateTime)business.closing;
            _business.name = business.name;
            _business.opening = (DateTime)business.opening;
            _business.websiteLink = business.websiteLink;
            _business.id = Guid.NewGuid();
            context.Businesses.Add(_business);
            context.SaveChanges();
            return _business;
        }

        public void DeleteBusiness(Guid id)
        {
            context.Businesses.Remove(GetBusiness(id));
            context.SaveChanges();
        }

        public Business EditBusiness(Guid id, BusinessDTO business)
        {
            var existing = context.Businesses.Find(id);
            existing.name = business.name;
            existing.address = business.address;
            existing.opening = (DateTime)business.opening;
            existing.closing = (DateTime)business.closing;
            existing.websiteLink = business.websiteLink;
            existing.accountNumber = business.accountNumber;
            context.Businesses.Update(existing);
            context.SaveChanges();
            return existing;
        }

        public Business PatchBusiness(Guid id, BusinessDTO business)
        {
            var existing = context.Businesses.Find(id);
            if (existing != null)
            {
                existing = EntityHelper.PatchEntity<Business>(existing, business);
                context.Businesses.Update(existing);
                context.SaveChanges();
                return existing;
            }
            else
            {
                return null;
            }
        }

        public Business GetBusiness(Guid id)
        {
            return context.Businesses.Find(id);
        }

        public List<Business> GetBusinesses()
        {
            return context.Businesses.ToList();
        }
    }
}
