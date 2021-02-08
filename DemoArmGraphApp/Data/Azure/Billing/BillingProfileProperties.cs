namespace DemoArmGraphApp.Data.Azure.Billing
{
    public class BillingProfileProperties
    {
        public string displayName { get; set; }
        public string billingRelationshipType { get; set; }
        public string currency { get; set; }
        public int invoiceDay { get; set; }
        public string poNumber { get; set; }
        public string status { get; set; }
        public string statusReasonCode { get; set; }
        public BillingAddress billTo { get; set; }
        //public string enabledAzurePlans { get; set; }
        //public string indirectRelationshipInfo { get; set; }
        //public bool invoiceEmailOptIn { get; set; }
        //public string spendingLimit { get; set; }
        //public string targetClouds { get; set; }
    }
}
