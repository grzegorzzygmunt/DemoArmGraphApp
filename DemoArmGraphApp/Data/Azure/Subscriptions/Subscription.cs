namespace DemoArmGraphApp.Data.Azure.Subscriptions
{
    public class Subscription
    {
        public string id { get; set; }
        public string subscriptionId { get; set; }
        public string tenantId { get; set; }
        public string displayName { get; set; }
        public string state { get; set; }
        //public string subscriptionPolicies { get; set; }
        public string authorizationSource { get; set; }
        //public string managedByTenants { get; set; }
        //public string tags { get; set; }
    }
}
