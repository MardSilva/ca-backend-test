using System;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CA.BackendTest.Services
{
    public class BillingService : ITransientDependency
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BillingService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<HttpResponseMessage> GetBillingDataAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing");
            response.EnsureSuccessStatusCode();
            return response;
        }

        public async Task<HttpResponseMessage> GetBillingLinesDataAsync(string billingId)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync($"https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing/{billingId}");
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}