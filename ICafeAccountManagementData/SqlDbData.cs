using ICafeAccountModels;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
//Liam
//INTEG FINAL
namespace ICafeAccountManagementData
{
    public class SqlDBData
    {
         string connectionString
            = "Server = tcp:52.139.168.198,1433; Database = ICafe Account Management; User Id = sa; Password = LiamPogi123!";

        SqlConnection sqlConnection;
        
        public SqlDBData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }


        public List<User> GetUsers()
        {
            string selectStatement = "SELECT username, password FROM Users";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<User> users = new List<User>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string username = reader["username"].ToString();
                string password = reader["password"].ToString();

                User readUser = new User();
                readUser.username = username;
                readUser.password = password;
                users.Add(readUser);
            }

            sqlConnection.Close();

            return users;
        }

        public int AddUser(string username, string password)
        {
            int success;

            string insertStatement = "INSERT INTO users VALUES (@username, @password )";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@password", password);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdateUser(string username, string password)
        {
            int success;

            string updateStatement = $"UPDATE users SET password = @Password WHERE username = @username";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@Password", password);
            updateCommand.Parameters.AddWithValue("@username", username);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteUser(string username)
        {
            int success;

            string deleteStatement = $"DELETE FROM users WHERE username = @username";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@username", username);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}

