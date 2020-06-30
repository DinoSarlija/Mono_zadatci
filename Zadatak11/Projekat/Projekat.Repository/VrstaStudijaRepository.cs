using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Projekat.Model;
using Projekat.Repository.Common;
using Projekat.Common;
using System.Diagnostics;

namespace Projekat.Repository
{
    public class VrstaStudijaRepository : IVrstaStudijaRepository
    {
        readonly string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
        
        public List<VrstaStudija> vrsta_studija_lista = new List<VrstaStudija>();
        
        public async Task<List<VrstaStudija>> SelectVrstaStudijaAsync()
        {
            string queryString = "select * from vrsta_studija;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        VrstaStudija VrstaStudija1 = new VrstaStudija { id = reader.GetGuid(0), naziv = reader.GetString(1), trajanje_studija = reader.GetInt32(2) };
                        vrsta_studija_lista.Add(VrstaStudija1);
                    }
                }

                reader.Close();
                connection.Close();
            }
            return await Task.FromResult(vrsta_studija_lista);
        }

        public async Task<List<VrstaStudija>> SelectAllVrstaStudijaAsync(Filter filter, Sort sort, Page page)
        {
            string queryString = "";

            if (page != null)
            {
                int begginingRow = (page.PageNumber - 1) * page.PageSize;
                int endRow = begginingRow + page.PageSize + 1;
                queryString += "DECLARE @BegginingRow INT = " + begginingRow + ";" + "DECLARE @EndRow INT = " + endRow + ";";
            }
            else
            {
                Debug.WriteLine("else");
                queryString += "DECLARE @BegginingRow INT = " + 0 + ";" + "DECLARE @EndRow INT = " + 6 + ";";
            }

            queryString += "select vrsta_studija_id,naziv, trajanje_studija from " +
                "(" + "SELECT ROW_NUMBER() OVER(ORDER BY vrsta_studija_id) AS RowNum, vrsta_studija_id, naziv, trajanje_studija " +
                    "FROM vrsta_studija" + ") AS tbl  where @BegginingRow<RowNum and @EndRow > RowNum ";

            if (filter != null)
            {
                if(filter.naziv != "" & filter.trajanje_studija != 0)
                { 
                    queryString += " where naziv = '" + filter.naziv + "' and trajanje_studija = " + filter.trajanje_studija;
                }
                else if(filter.naziv != "")
                {
                    queryString += " where naziv = '" + filter.naziv + "'";
                }
                else if(filter.trajanje_studija != 0)
                {
                    queryString += " where trajanje_studija = " + filter.trajanje_studija;
                }
            }
            
            if(sort != null)
            {
                if (sort.Order != "desc")
                {
                    sort.Order = "asc";
                }
                if (sort.OrderBy != "trajanje_studija")
                {
                    sort.OrderBy = "naziv";
                }
                queryString += " order by " + sort.OrderBy + " " + sort.Order;  
            }

            queryString += ";";
            Debug.WriteLine(queryString);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        VrstaStudija VrstaStudija1 = new VrstaStudija { id = reader.GetGuid(0), naziv = reader.GetString(1), trajanje_studija = reader.GetInt32(2) };
                        vrsta_studija_lista.Add(VrstaStudija1);
                    }
                }
                reader.Close();
                connection.Close();
            }

            return await Task.FromResult(vrsta_studija_lista);
        }

        public async Task<List<VrstaStudija>> SelectByIdVrstaStudijaAsync(Guid id)
        {
            string queryString = "SELECT * FROM vrsta_studija WHERE vrsta_studija_id = @ID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    VrstaStudija vrsta_studija = new VrstaStudija { id = reader.GetGuid(0), naziv = reader.GetString(1), trajanje_studija = reader.GetInt32(2) };
                    vrsta_studija_lista.Add(vrsta_studija);
                }

                reader.Close();
                connection.Close();
            }
            return await Task.FromResult(vrsta_studija_lista);
        }


        //Inserting row in table in SQL
        public async Task<bool> InsertVrstaStudijaAsync(VrstaStudija vrsta_studija)
        {
            string queryString = " INSERT INTO vrsta_studija (naziv, trajanje_studija) VALUES('" + vrsta_studija.naziv + "', '" + vrsta_studija.trajanje_studija + "');";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();

                connection.Open();
                int insert = command.ExecuteNonQuery();
                connection.Close();

                if (insert == 0)
                {
                    return await Task.FromResult(false);
                }
                return await Task.FromResult(true);
            }
        }

        //Updateing row in table in SQL
        public async Task<bool> UpdateVrstaStudijaAsync(VrstaStudija vrsta_studija, Guid Id)
        {
            string queryString = " update vrsta_studija set naziv = '" + vrsta_studija.naziv + "',trajanje_studija = ' " + vrsta_studija.trajanje_studija + " ' where vrsta_studija_id = @ID; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", Id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();

                connection.Open();
                int update = command.ExecuteNonQuery();
                connection.Close();

                if (update == 0)
                {
                    return await Task.FromResult(false);
                }
                return await Task.FromResult(true);
            }
        }

        //Deleting row in table in SQL
        public async Task<bool> DeleteVrstaStudijaAsync(Guid Id)
        {
            string queryString = " delete from vrsta_studija where vrsta_studija_id = @ID; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@ID", Id);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
                
                connection.Open();
                int deleted = command.ExecuteNonQuery();
                connection.Close();

                if (deleted == 0)
                {
                    return await Task.FromResult(false);
                }
                return await Task.FromResult(true);
                
            }
        }
        
    }
}
