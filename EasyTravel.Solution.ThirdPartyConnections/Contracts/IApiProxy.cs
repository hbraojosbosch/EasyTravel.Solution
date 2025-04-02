namespace EasyTravel.Solution.ThirdPartyConnections.Contracts
{
    public interface IApiProxy
    {
        Task<string> PostAsync(string url, string accessToken, object content);
        Task<string> GetAsync(string url, string accessToken, Dictionary<string, string> content);
    }
}