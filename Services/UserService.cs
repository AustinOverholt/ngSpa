using ngSpa.Model;
using ngSpa.Model.Domain;
using ngSpa.Model.Requests;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ngSpa.Services
{
    public class UserService : BaseService
    {
        // Select
        public List<Users> SelectAll()
        {
            List<Users> userList = new List<Users>();
            using (SqlConnection conn = new SqlConnection(connString))
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

        // Select By Id
        public  Users SelectById(int id)
        {
            Users model = new Users();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Users_SelectById", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                        model = Mapper(reader);
                }
                conn.Close();
            }
            return model;
        }

        // Insert
        public int Insert(UserAddRequest model)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Users_Insert", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleInitial", model.MiddleInitial);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);

                    SqlParameter parm = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    parm.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(parm);

                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;
                }
                conn.Close();
            }
            return id;
        }

        // Update
        public void Update(UserUpdateRequest model)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Users_Update", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleInitial", model.MiddleInitial);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);
                    cmd.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // Delete
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Users_Delete", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // Grid
        public UsersGrid GetGrid(GridRequest model)
        {
            UsersGrid singleItem = new UsersGrid();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Users_Grid", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DisplayLength", model.displayLength);
                    cmd.Parameters.AddWithValue("@DisplayStart", model.displayStart);
                    cmd.Parameters.AddWithValue("@SortCol", model.sortCol);
                    cmd.Parameters.AddWithValue("@SortDir", model.sortDir);
                    cmd.Parameters.AddWithValue("@Search", model.search);

                    SqlDataReader reader = cmd.ExecuteReader();
                    short set = new short();

                    switch (set)
                    {
                        case 0:
                            singleItem.recordsTotal = reader.GetInt32(0);
                            break;
                        case 1:
                            singleItem.recordsFiltered = reader.GetInt32(0);
                            break;
                        case 2:
                            Users u = Mapper(reader);
                            if(singleItem.data == null)
                            {
                                singleItem.data = new List<Users>();
                            }
                            singleItem.data.Add(u);
                            break;
                        default:
                            singleItem = null;
                            break;
                    }
                }
                conn.Close();
            }
            return singleItem;
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
