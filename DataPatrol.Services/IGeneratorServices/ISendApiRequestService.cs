namespace DataPatrol.Services.IGeneratorServices
{
    public interface ISendApiRequestService
    {
        Task<string> SendApiRequest(string endPoint);
    }
}
