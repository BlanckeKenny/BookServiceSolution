using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookService.Lib.Helpers
{
    public class WebApiHelper
    {
        public static T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response.Result)).Result;
            }
        }

        public static async Task<TOut> PutCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Put);
        }
        public static async Task<TOut> PostCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Post);
        }
        public static async Task<TOut> DelCallApi<TOut>(string uri)
        {
            return await CallApi<TOut, object>(uri, null, HttpMethod.Delete);
        }
        private static async Task<TOut> CallApi<TOut, TIn>(string uri, TIn entity,
            HttpMethod method)
        {
            TOut result = default(TOut);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response;
                if (method == HttpMethod.Post)
                {
                    response = await httpClient.PostAsJsonAsync(uri, entity);
                }
                else if (method == HttpMethod.Put)
                {
                    response = await httpClient.PutAsJsonAsync(uri, entity);
                }
                else
                {
                    response = await httpClient.DeleteAsync(uri);
                }
                result = await response.Content.ReadAsAsync<TOut>();
            }
            return result;
        }
    }
}
