using DemoArmGraphApp.Data.Azure;
using DemoArmGraphApp.Data.Azure.Billing;
using DemoArmGraphApp.Data.Azure.Subscriptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using RestSharp;
using System.Threading.Tasks;

namespace DemoArmGraphApp.Data
{
    public class AzureRestClient : BaseRestClient
    {
        private const string subscriptionsApiVersionValue = "2020-01-01";
        private const string billingApiVersionValue = "2020-05-01";

        public AzureRestClient(IConfiguration configuration, ITokenAcquisition tokenAcquisition)
            : base(configuration, tokenAcquisition, "AzureApi")
        {
        }

        public async Task<IRestResponse<ResourceList<Subscription>>> GetSubscriptionsAsync()
        {
            var request = new RestRequest("subscriptions", DataFormat.Json)
                .AddParameter("api-version", subscriptionsApiVersionValue);
            await AddAuthorizationHeader(request);
            return await RestClient.Value.ExecuteAsync<ResourceList<Subscription>>(request, Method.GET).ConfigureAwait(false);
        }

        public async Task<IRestResponse<ResourceList<BillingAccount>>> GetBillingAccountsAsync()
        {
            var request = new RestRequest("providers/Microsoft.Billing/billingAccounts", DataFormat.Json)
                .AddParameter("api-version", billingApiVersionValue)
                .AddParameter("expand", "soldTo");
            await AddAuthorizationHeader(request);
            return await RestClient.Value.ExecuteAsync<ResourceList<BillingAccount>>(request, Method.GET).ConfigureAwait(false);
        }

        public async Task<IRestResponse<ResourceList<BillingProfile>>> GetBillingProfilesAsync(string billingAccountId)
        {
            var request = new RestRequest(billingAccountId + "/billingProfiles", DataFormat.Json)
                .AddParameter("api-version", billingApiVersionValue);
            await AddAuthorizationHeader(request);
            return await RestClient.Value.ExecuteAsync<ResourceList<BillingProfile>>(request, Method.GET).ConfigureAwait(false);
        }
    }
}
