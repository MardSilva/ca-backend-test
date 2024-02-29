using System;
using System.Net.Http;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CA.BackendTest.Services
{
    public class BillingService : ITransientDependency
    {
        private readonly HttpClient _httpClient;

        public BillingService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<HttpResponseMessage> GetBillingDataAsync()
        {
            // call the HTTP endpoint for the billing route
            var response = await _httpClient.GetAsync("https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing");
            response.EnsureSuccessStatusCode(); // throw an exception if the response is not successful

            return response;
        }

        public async Task<HttpResponseMessage> GetBillingLinesDataAsync(string billingId)
        {
            // call the HTTP endpoint for the billing lines route
            var response = await _httpClient.GetAsync($"https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing/{billingId}");
            response.EnsureSuccessStatusCode(); // throw an exception if the response is not successful

            return response;
        }
    }
}