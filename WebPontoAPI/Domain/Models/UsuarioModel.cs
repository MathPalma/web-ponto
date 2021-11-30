using System;

namespace Domain.Models
{
    public class UsuarioModel
    {
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenTempoExpiracao { get; set; }
    }
}
