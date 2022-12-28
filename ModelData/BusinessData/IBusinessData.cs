using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.BusinessData
{
    public interface IBusinessData
    {
        List<Business> GetBusinesses();
        Business GetBusiness(Guid id);
        Business AddBusiness(Business business);
        void DeleteBusiness(Guid id);
        Business EditBusiness(Business business);
    }
}
