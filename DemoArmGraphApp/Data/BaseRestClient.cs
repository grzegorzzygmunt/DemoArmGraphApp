using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace DemoArmGraphApp.Data
{
    public class BaseRestClient
    {
        private readonly string baseUrl;
        private readonly string[] scopes;
        private ITokenAcquisition tokenAcquisition;

        protected Lazy<RestClient> RestClient { get; }

        protected BaseRestClient(IConfiguration configuration, ITokenAcquisition tokenAcquisition, string apiConfigSection)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (apiConfigSection == null)
            {
                throw new ArgumentNullException(nameof(apiConfigSection));
            }
            this.tokenAcquisition = tokenAcquisition ?? throw new ArgumentNullException(nameof(tokenAcquisition));

            baseUrl = configuration.GetValue<string>($"{apiConfigSection}:BaseUrl");
            scopes = configuration.GetValue<string>($"{apiConfigSection}:Scopes")?.Split(' ');

            RestClient = new Lazy<RestClient>(() =>
            {
                return new RestClient(baseUrl);
            });
        }

        protected async Task AddAuthorizationHeader(IRestRequest request)
        {
            request.AddHeader("Authorization", "Bearer " + await tokenAcquisition.GetAccessTokenForUserAsync(scopes));
        }
    }
}
