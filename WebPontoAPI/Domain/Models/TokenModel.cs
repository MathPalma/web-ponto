namespace Domain.Models
{
    public class TokenModel
    {
        public string Name { get; set; }
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public TokenModel(string name, bool authenticated, string created, string expiration, string accessToken, string refreshToken)
        {
            Name = name;
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
