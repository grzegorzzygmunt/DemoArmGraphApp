namespace DemoArmGraphApp.Data.Azure.Billing
{
    public class BillingAccountProperties
    {
        public string displayName { get; set; }
        public string agreementType { get; set; }
        public string accountStatus { get; set; }
        public string accountType { get; set; }
        public BillingAddress soldTo { get; set; }
        //public string enrollmentDetails { get; set; }
        //public string departments { get; set; }
        //public string enrollmentAccounts { get; set; }
        //public string billingProfiles { get; set; }
    }
}
