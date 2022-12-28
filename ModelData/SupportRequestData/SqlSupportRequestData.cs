using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.SupportRequestData
{
    public class SqlSupportRequestData : ISupportRequestData
    {
        private PointOfSaleContext context;
        public SqlSupportRequestData(PointOfSaleContext _context)
        {
            context = _context;
        }

        public SupportRequest AddSupportRequest(SupportRequest supportRequest)
        {
            supportRequest.id = Guid.NewGuid();
            context.SupportRequests.Add(supportRequest);
            context.SaveChanges();
            return supportRequest;
        }

        public void DeleteSupportRequest(Guid id)
        {
            context.SupportRequests.Remove(GetSupportRequest(id));
            context.SaveChanges();
        }

        public SupportRequest EditSupportRequest(SupportRequest supportRequest)
        {
            var existing = context.SupportRequests.Find(supportRequest.id);
            existing.employeeId = supportRequest.employeeId;
            existing.businessId = supportRequest.businessId;
            existing.orderId = supportRequest.orderId;
            existing.customerId = supportRequest.customerId;
            existing.issue = supportRequest.issue;
            existing.status = supportRequest.status;
            existing.type = supportRequest.type;
            existing.requestedOn = supportRequest.requestedOn;
            existing.solvedOn = supportRequest.solvedOn;
            context.SupportRequests.Update(existing);
            context.SaveChanges();
            return supportRequest;
        }

        public SupportRequest GetSupportRequest(Guid id)
        {
            return context.SupportRequests.Find(id);
        }

        public List<SupportRequest> GetSupportRequests()
        {
            return context.SupportRequests.ToList();
        }
    }
}
