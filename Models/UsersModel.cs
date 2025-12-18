using Microsoft.AspNetCore.Mvc;

namespace Tools.Models
{
    public class UsersModel
    {
        public int Id_User { get; set; }
        public string? Username_User { get; set; }
        public string? Password_User { get; set; }
        public string? Email_User { get; set; }
        public string? Status_User { get; set; }
        public string? Nombre_User { get; set; }
        public string? Apellidos_User { get; set; }
    }
}
