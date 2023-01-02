using Point_of_Sale_Lab3.Models;

namespace Point_of_Sale_Lab3.ModelData.SupportRequestData
{
    public interface ISupportRequestData
    {
        List<SupportRequest> GetSupportRequests();
        SupportRequest GetSupportRequest(Guid id);
        SupportRequest AddSupportRequest(SupportRequestDTO supportRequest);
        void DeleteSupportRequest(Guid id);
        SupportRequest EditSupportRequest(Guid id, SupportRequestDTO supportRequest);
        SupportRequest PatchSupportRequest(Guid id, SupportRequestDTO supportRequest);
    }
}
