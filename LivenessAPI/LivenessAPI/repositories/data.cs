namespace LivenessAPI.repositories
{
    public class data
    {
        public data() { }

        #region Properties
        public string transactionGuid { get; set; }
        public string shortGuid { get; set; }
        public string requestTimestamp { get; set; }
        public string responseTimestamp { get; set; }
        public string verified { get; set; }
        public string center { get; set; }
        public string isException { get; set; }

        public Person person { get; set; }
        public string success { get; set; }
        public string code { get; set; }

        #endregion

    }

    public struct Person
    {

        #region Properties

        public string nationalId { get; set; }
        public string cardId { get; set; }
        public string cardValidFrom { get; set; }
        public string cardValidTo { get; set; }
        public string surname { get; set; }
        public string forenames { get; set; }
        public string nationality { get; set; }
        public string birthDate { get; set; }
        public string gender { get; set; }
        public string birthCountry { get; set; }
        public string birthDistrict { get; set; }
        public string birthRegion { get; set; }
        public string birthTown { get; set; }

        public Address[] addresses { get; set; }

        public Contact contact { get; set; }

        public BiometricFeed biometricFeed { get; set; }
        public Binary[] binaries { get; set; }

        #endregion
    }

    public struct Binary
    {
        public string type { get; set; }
        public string dataType { get; set; }
        public string data { get; set; }
    }
    public struct Phone
    {
        public string type { get; set; }
        public string phoneNumber { get; set; }
        public string network { get; set; }
    }

    public struct GPS
    {

        public string gpsName { get; set; }
    }

    public struct Contact
    {

        public string email { get; set; }
        public Phone[] phoneNumbers { get; set; }
    }

    public struct Face
    {
        public string dataType { get; set; }
        public string data { get; set; }
    }

    public struct BiometricFeed
    {
        public Face face { get; set; }
    }

    public struct Address
    {

        #region Properties of Address class

        public string type { get; set; }
        public string community { get; set; }
        public string postalCode { get; set; }
        public string region { get; set; }
        public string addressDigital { get; set; }

        #endregion
    }


}
