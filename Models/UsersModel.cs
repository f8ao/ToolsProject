using Microsoft.AspNetCore.Mvc;

namespace Tools.Models
{
    public class UsersModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Roles { get; set; }
    }
}
