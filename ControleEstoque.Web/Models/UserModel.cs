using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.Web.Models
{
    public class UserModel
    {
        public static bool UserValidate(string login, string senha)
        {
            bool autho = false;
            string connectionString = @"Integrated Security=SSPI;Persist Security " +
                                       "Info=False;User ID='';Initial Catalog=Stock;Data Source=.;Initial " +
                                       "File Name=''";

            string commandText = @"SELECT COUNT(*) FROM Usuario WHERE email = @email AND senha = @senha";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@email", login);
                    command.Parameters.AddWithValue("@senha", senha);

                    auth = ((int)command.ExecuteScalar() > 0);
                }
            }

            return auth;
        }
    }
}