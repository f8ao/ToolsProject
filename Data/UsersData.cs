using Microsoft.Data.SqlClient;
using System.Data;
using Tools.Models;

namespace Tools.Data
{
    public class UsersData
    {
        public List<UsersModel> FetchUsers()
        {
            var oListUsers = new List<UsersModel>();
            var cn = new Connection();
            using (var connection = new SqlConnection(cn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spFetchUsers", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListUsers.Add(new UsersModel()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Username = dr["Username"].ToString(),
                            Password = dr["Password"].ToString(),
                            Email = dr["Email"].ToString(),
                            Status = dr["Status"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            Roles = dr["Roles"].ToString()
                        });
                    }
                }
            }
            return oListUsers;
        }
        public UsersModel FetchUser(int? Id)
        {
            var oUser = new UsersModel();
            var cn = new Connection();
            using (var connection = new SqlConnection(cn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spFetchUser", connection);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUser.Id = Convert.ToInt32(dr["Id"]);
                        oUser.Username = dr["Username"].ToString();
                        oUser.Password = dr["Password"].ToString();
                        oUser.Email = dr["Email"].ToString();
                        oUser.Status = dr["Status"].ToString();
                        oUser.Nombre = dr["Nombre"].ToString();
                        oUser.Apellidos = dr["Apellidos"].ToString();
                        oUser.Roles = dr["Roles"].ToString();
                    }
                }
            }
            return oUser;
        }
        public UsersModel ValidateUser(string? Email, string? Password)
        {
            var oUser = new UsersModel();
            var cn = new Connection();
            using (var connection = new SqlConnection(cn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spValidateUser", connection);
                cmd.Parameters.AddWithValue("Email", Email);
                cmd.Parameters.AddWithValue("Password", Password);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUser.Id = Convert.ToInt32(dr["Id"]);
                        oUser.Username = dr["Username"].ToString();
                        oUser.Password = dr["Password"].ToString();
                        oUser.Email = dr["Email"].ToString();
                        oUser.Status = dr["Status"].ToString();
                        oUser.Nombre = dr["Nombre"].ToString();
                        oUser.Apellidos = dr["Apellidos"].ToString();
                        oUser.Roles = dr["Roles"].ToString();
                    }
                }
            }
            return oUser;
        }
        public bool NewUser(UsersModel oUser)
        {
            bool rpta;
            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spNewUser", connection);
                    cmd.Parameters.AddWithValue("Username", oUser.Username);
                    cmd.Parameters.AddWithValue("Password", oUser.Password);
                    cmd.Parameters.AddWithValue("Email", oUser.Email);
                    cmd.Parameters.AddWithValue("Status", oUser.Status);
                    cmd.Parameters.AddWithValue("Nombre", oUser.Nombre);
                    cmd.Parameters.AddWithValue("Apellidos", oUser.Apellidos);
                    cmd.Parameters.AddWithValue("Roles", oUser.Roles);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool UpdateUser(UsersModel oUser)
        {
            bool rpta;
            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateUser", connection);
                    cmd.Parameters.AddWithValue("Id", oUser.Id);
                    cmd.Parameters.AddWithValue("Username", oUser.Username);
                    cmd.Parameters.AddWithValue("Password", oUser.Password);
                    cmd.Parameters.AddWithValue("Email", oUser.Email);
                    cmd.Parameters.AddWithValue("Status", oUser.Status);
                    cmd.Parameters.AddWithValue("Nombre", oUser.Nombre);
                    cmd.Parameters.AddWithValue("Apellidos", oUser.Apellidos);
                    cmd.Parameters.AddWithValue("Roles", oUser.Roles);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool DeleteUser(int? Id)
        {
            bool rpta;
            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteUser", connection);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
    }

}
