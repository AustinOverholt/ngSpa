using HtmlAgilityPack;
using ngSpa.Model.Domain;
using ngSpa.Model.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ngSpa.Services
{
    public class ScrapeService : BaseService
    {
        // pass in link to be parsed
        public List<string> Scrape(Scrape model)
        {

            var document = new HtmlWeb().Load(model.html);
            var urls = document.DocumentNode.Descendants("img")
                                            .Select(e => e.GetAttributeValue("src", null))
                                            .Where(s => !String.IsNullOrEmpty(s));
            List<string> list = urls.ToList();
            List<string> newList = new List<string>();
            foreach (var item in list)
            {
                newList.Add(item);
            }
            return newList;
        }

        // Insert
        public int ScrapeInsert(ScrapeAddRequest model)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.ScrapedData_Insert", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ScrapedData", model.ScrapedData);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

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

        // Select All
        public List<ScrapeDb> SelectAll()
        {
            List<ScrapeDb> scrapeList = new List<ScrapeDb>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.ScrapedData_SelectAll", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        ScrapeDb model = Mapper(reader);
                        scrapeList.Add(model);
                    }
                }
                conn.Close();
            }
            return scrapeList;
        }

        // Delete 
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.ScrapedData_Delete", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // Mapper
        private ScrapeDb Mapper(SqlDataReader reader)
        {
            ScrapeDb model = new ScrapeDb();
            int index = 0;

            model.Id = reader.GetInt32(index++);
            model.ScrapedData = reader.GetString(index++);
            model.CreatedDate = reader.GetDateTime(index++);
            model.ModifiedDate = reader.GetDateTime(index++);
            model.ModifiedBy = reader.GetString(index++);

            return model;
        }
    }
}
