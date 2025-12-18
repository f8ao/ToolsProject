using Microsoft.AspNetCore.Components.Routing;
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
                            Id_User = Convert.ToInt32(dr["Id_User"]),
                            Username_User = dr["Username_User"].ToString(),
                            Password_User = dr["Password_User"].ToString(),
                            Email_User = dr["Email_User"].ToString(),
                            Status_User = dr["Status_User"].ToString(),
                            Nombre_User = dr["Nombre_User"].ToString(),
                            Apellidos_User = dr["Apellidos_User"].ToString()
                        });
                    }
                }
            }
            return oListUsers;
        }
        public UsersModel FetchUser(int Id_User)
        {
            var oUser = new UsersModel();
            var cn = new Connection();
            using (var connection = new SqlConnection(cn.GetConnectionString()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("spFetchUser", connection);
                cmd.Parameters.AddWithValue("Id_User", Id_User);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUser.Id_User = Convert.ToInt32(dr["Id_User"]);
                        oUser.Username_User = dr["Username_User"].ToString();
                        oUser.Password_User = dr["Password_User"].ToString();
                        oUser.Email_User = dr["Email_User"].ToString();
                        oUser.Status_User = dr["Status_User"].ToString();
                        oUser.Nombre_User = dr["Nombre_User"].ToString();
                        oUser.Apellidos_User = dr["Apellidos_User"].ToString();
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
                    cmd.Parameters.AddWithValue("Username_User", oUser.Username_User);
                    cmd.Parameters.AddWithValue("Password_User", oUser.Password_User);
                    cmd.Parameters.AddWithValue("Email_User", oUser.Email_User);
                    cmd.Parameters.AddWithValue("Status_User", oUser.Status_User);
                    cmd.Parameters.AddWithValue("Nombre_User", oUser.Nombre_User);
                    cmd.Parameters.AddWithValue("Apellidos_User", oUser.Apellidos_User);
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
                    cmd.Parameters.AddWithValue("Id_User", oUser.Id_User);
                    cmd.Parameters.AddWithValue("Username_User", oUser.Username_User);
                    cmd.Parameters.AddWithValue("Password_User", oUser.Password_User);
                    cmd.Parameters.AddWithValue("Email_User", oUser.Email_User);
                    cmd.Parameters.AddWithValue("Status_User", oUser.Status_User);
                    cmd.Parameters.AddWithValue("Nombre_User", oUser.Nombre_User);
                    cmd.Parameters.AddWithValue("Apellidos_User", oUser.Apellidos_User);
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
        public bool DeleteUser(int Id_User)
        {
            bool rpta;
            try
            {
                var cn = new Connection();
                using (var connection = new SqlConnection(cn.GetConnectionString()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteUser", connection);
                    cmd.Parameters.AddWithValue("Id_User", Id_User);
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
