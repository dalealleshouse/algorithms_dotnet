namespace Algorithms.Benchmarker
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public static class FileDownloader
    {
        public static async Task<string> DownloadFile(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
