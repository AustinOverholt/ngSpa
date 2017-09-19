using ngSpa.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngSpa.Services
{
    public class UserService : BaseService
    {
        public List<Users> SelectAll()
        {
            List<Users> userList = new List<Users>();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Users_SelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Users model = Mapper(reader);
                        userList.Add(model);
                    }
                }
                    conn.Close();
            }
            return userList;
        }

        private Users Mapper(SqlDataReader reader)
        {
            Users model = new Users();
            int index = 0;

            model.Id = reader.GetInt32(index++);
            model.FirstName = reader.GetString(index++);
            if (!reader.IsDBNull(index)) // Because this value can be nullable, checks if null if so index++
            {
                model.MiddleInitial = reader.GetString(index++);
            }
            else
            {
                index++;
            }
            model.LastName = reader.GetString(index++);
            model.CreatedDate = reader.GetDateTime(index++);
            model.ModifiedDate = reader.GetDateTime(index++);
            model.ModifiedBy = reader.GetString(index++);
            if (!reader.IsDBNull(index))
            {
                model.PhoneNumber = reader.GetString(index++);
            }
            else
            {
                index++;
            }

            return model;
        }
    }
}
