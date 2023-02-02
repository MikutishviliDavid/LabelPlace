namespace LabelPlace.Api.Configurations
{
    public class LabelPlaceJwtConfiguration
    {
        public string Key { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int Lifetime { get; set; }
    }
}
