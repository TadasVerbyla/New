using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.BusinessData
{
    public class SqlBusinessData : IBusinessData
    {
        private PointOfSaleContext context;
        public SqlBusinessData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public Business AddBusiness(Business business)
        {
            business.id = Guid.NewGuid();
            context.Businesses.Add(business);
            context.SaveChanges();
            return business;
        }

        public void DeleteBusiness(Guid id)
        {
            context.Businesses.Remove(GetBusiness(id));
            context.SaveChanges();
        }

        public Business EditBusiness(Business business)
        {
            var existing = context.Businesses.Find(business.id);
            existing.name = business.name;
            existing.address = business.address;
            existing.opening = business.opening;
            existing.closing = business.closing;
            existing.websiteLink = business.websiteLink;
            existing.accountNumber = business.accountNumber;
            context.Businesses.Update(existing);
            context.SaveChanges();
            return business;
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
