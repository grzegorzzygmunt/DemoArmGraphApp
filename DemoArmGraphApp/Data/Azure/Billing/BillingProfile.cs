namespace DemoArmGraphApp.Data.Azure.Billing
{
    public class BillingProfile
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public BillingProfileProperties properties { get; set; }
    }
}
