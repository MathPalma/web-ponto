using Newtonsoft.Json;
using System;

namespace Domain.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        [JsonProperty("userName")]
        public string Usuario { get; set; }
        [JsonProperty("fullName")]
        public string Nome { get; set; }
        [JsonProperty("password")]
        public string Senha { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("cellphone")]
        public long Telefone { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenTempoExpiracao { get; set; }
    }
}
