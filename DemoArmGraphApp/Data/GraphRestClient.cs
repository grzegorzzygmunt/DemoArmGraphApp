using DemoArmGraphApp.Data.Graph;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace DemoArmGraphApp.Data
{
    public class GraphRestClient : BaseRestClient
    {
        public GraphRestClient(IConfiguration configuration, ITokenAcquisition tokenAcquisition) 
            : base(configuration, tokenAcquisition, "GraphApi")
        {
        }

        public async Task<IRestResponse<UserProfile>> GetProfileAsync()
        {
            var request = new RestRequest("me", DataFormat.Json);
            await AddAuthorizationHeader(request);
            return await RestClient.Value.ExecuteAsync<UserProfile>(request, Method.GET).ConfigureAwait(false);
        }
    }
}
