namespace CountryGWP.API.Repositories
{
    public interface IGWPRepository
    {
        Task<Dictionary<string, decimal>> GetAverageGwpAsync(string country, List<string> lob);
    }
}
