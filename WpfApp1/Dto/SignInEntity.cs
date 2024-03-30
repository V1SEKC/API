using System.Text.Json.Serialization;

namespace WpfApp1.Dto
{
    public record SignInEntity
    {
        [JsonPropertyName("tokenType")]
        public string TokenType { get; set; }
        
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expiresIn")]
        public string ExpitesIn { get; set; }
        
        [JsonPropertyName("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
