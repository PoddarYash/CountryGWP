namespace CountryGWP.API.Repositories
{
    public interface IGWPRepository
    {
        Task<Dictionary<string, decimal>> CalculateAverageGwpAsync(string country, List<string> lob);
    }
}
