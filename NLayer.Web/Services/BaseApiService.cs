

namespace NLayer.Web.Services
{
    public class BaseApiService
    {
        protected readonly HttpClient _httpClient;

        public BaseApiService(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
        }

    }
}
