using Point_of_Sale_Lab3.DB;
using Point_of_Sale_Lab3.Helpers;
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
            _supportRequest.businessId = (Guid)supportRequest.businessId;
            _supportRequest.customerId = (Guid)supportRequest.customerId;
            _supportRequest.employeeId = (Guid)supportRequest.employeeId;
            _supportRequest.issue = supportRequest.issue;
            _supportRequest.orderId = (Guid)supportRequest.orderId;
            _supportRequest.requestedOn = (DateTime)supportRequest.requestedOn;
            _supportRequest.solvedOn = (DateTime)supportRequest.solvedOn;
            _supportRequest.status = (SupportStatus)supportRequest.status;
            _supportRequest.type = (SupportType)supportRequest.type;
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
            existing.employeeId = (Guid)supportRequest.employeeId;
            existing.businessId = (Guid)supportRequest.businessId;
            existing.orderId = (Guid)supportRequest.orderId;
            existing.customerId = (Guid)supportRequest.customerId;
            existing.issue = supportRequest.issue;
            existing.status = (SupportStatus)supportRequest.status;
            existing.type = (SupportType)supportRequest.type;
            existing.requestedOn = (DateTime)supportRequest.requestedOn;
            existing.solvedOn = (DateTime)supportRequest.solvedOn;
            context.SupportRequests.Update(existing);
            context.SaveChanges();
            return existing;
        }

        public SupportRequest PatchSupportRequest(Guid id, SupportRequestDTO customer)
        {
            var existing = context.SupportRequests.Find(id);
            if (existing != null)
            {
                existing = EntityHelper.PatchEntity<SupportRequest>(existing, customer);
                context.SupportRequests.Update(existing);
                context.SaveChanges();
                return existing;
            }
            else
            {
                return null;
            }
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
