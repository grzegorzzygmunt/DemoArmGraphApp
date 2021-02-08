namespace DemoArmGraphApp.Data.Azure.Billing
{
    public class BillingAccount
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public BillingAccountProperties properties { get; set; }
    }
}
