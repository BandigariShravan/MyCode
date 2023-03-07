namespace DAL
{
    public class DriverLicense
    {
        public int DriverLicenseId { get; set; }
        public string? LicenseName { get; set; }
        public string? ExpiryDate { get; set; }
        public string? LicenseType { get; set; }
        //public int PersonId { get; set; }
    }
}
