using System.Text.Json.Serialization;
using WpfApp1.Infrastructure;

namespace WpfApp1.Dto
{
    public class LoginRequest : NotifyPropertyChangedObject
    {
        private string email;
        private string password;

        [JsonPropertyName("email")]
        public string Email 
        { 
            get { return email; } 
            set {  Set(ref email, value); } 
        }
        [JsonPropertyName("password")]
        public string Password
        {
            get { return password; }
            set { Set(ref password, value); }
        }
    }
}
