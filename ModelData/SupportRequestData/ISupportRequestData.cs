using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.SupportRequestData
{
    public interface ISupportRequestData
    {
        List<SupportRequest> GetSupportRequests();
        SupportRequest GetSupportRequest(Guid id);
        SupportRequest AddSupportRequest(SupportRequest supportRequest);
        void DeleteSupportRequest(Guid id);
        SupportRequest EditSupportRequest(SupportRequest supportRequest);
    }
}
