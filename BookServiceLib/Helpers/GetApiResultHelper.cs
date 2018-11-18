using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookService.Lib.Helpers
{
    public static class GetApiResultHelper
    {
        public static T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response.Result)).Result;
            }
        }
    }
}
