using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ProductApproval.Models;
using ProductApproval.Password_and_Authentication_Helpers;
using static ProductApproval.Password_and_Authentication_Helpers.HashProvider;

namespace ProductApproval.DAL
{
    public class UsersSqlDAO : IUsersDAO
    {
        private readonly string connectionString;
        public UsersSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private string GetAllUsersSql = "SELECT * FROM users";
        private string AddUserSql = "INSERT INTO users (role, username, password, salt) " +
            "VALUES(@role, @username, @password, @salt);";
        private string UpdateUserSql = "UPDATE users SET role = @role " +
            "WHERE userID = @id;";
        private string DeleteUserSql = "DELETE FROM users WHERE userID = @id";

        public IList<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(GetAllUsersSql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    allUsers.Add(MapReadToUser(reader));
                }
            }
            return allUsers;
        }

        public User AddUser(User user)
        {
            HashProvider hp = new HashProvider();
            HashedPassword hashedPassword = hp.HashPassword(user.Password);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(AddUserSql, conn);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", hashedPassword.Password);
                cmd.Parameters.AddWithValue("@salt", hashedPassword.Salt);
                cmd.Parameters.AddWithValue("@lastname", user.LastName);
                cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                cmd.ExecuteNonQuery();

                return user;
            }
        }

        public User UpdateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(UpdateUserSql, conn);
                cmd.Parameters.AddWithValue("@role", user.Role);
                cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                cmd.Parameters.AddWithValue("@lastName", user.LastName);

                cmd.ExecuteNonQuery();
            }

            return user;
        }

        public User DeleteUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(DeleteUserSql, conn);
                cmd.Parameters.AddWithValue("@userId", user.UserId);

                cmd.ExecuteNonQuery();

            }
            return user;
        }

        private User MapReadToUser(SqlDataReader reader)
        {
            User user = new User();

            user.UserId = Convert.ToInt32(reader["userID"]);
            user.Username = Convert.ToString(reader["username"]);
            user.Role = Convert.ToString(reader["role"]);

            return user;
        }
    }
}
