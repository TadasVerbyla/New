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

        public SupportRequest AddSupportRequest(SupportRequestDTO supportRequest)
        {
            SupportRequest _supportRequest = new SupportRequest();
            _supportRequest.businessId = supportRequest.businessId;
            _supportRequest.customerId = supportRequest.customerId;
            _supportRequest.employeeId = supportRequest.employeeId;
            _supportRequest.issue = supportRequest.issue;
            _supportRequest.orderId = supportRequest.orderId;
            _supportRequest.requestedOn = supportRequest.requestedOn;
            _supportRequest.solvedOn = supportRequest.solvedOn;
            _supportRequest.status = supportRequest.status;
            _supportRequest.type = supportRequest.type;
            _supportRequest.id = Guid.NewGuid();
            context.SupportRequests.Add(_supportRequest);
            context.SaveChanges();
            return _supportRequest;
        }

        public void DeleteSupportRequest(Guid id)
        {
            context.SupportRequests.Remove(GetSupportRequest(id));
            context.SaveChanges();
        }

        public SupportRequest EditSupportRequest(Guid id, SupportRequestDTO supportRequest)
        {
            var existing = context.SupportRequests.Find(id);
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
            return existing;
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
