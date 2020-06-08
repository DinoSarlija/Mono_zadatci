using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Projekat.Model;
using Projekat.Repository.Common;

namespace Projekat.Repository
{
    public class VrstaStudijaRepository : IVrstaStudijaRepository
    {
        public List<VrstaStudija> vrsta_studija_lista = new List<VrstaStudija>();
        public VrstaStudijaRepository() { }

        //Selecting table from SQL
        public async Task<List<VrstaStudija>> SelectVrstaStudijaRepositoryAsync()
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = "select vrsta_studija_id,naziv,trajanje_studija from vrsta_studija;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        VrstaStudija VrstaStudija1 = new VrstaStudija { vrsta_studija_id = reader.GetGuid(0), naziv = reader.GetString(1), trajanje_studija = reader.GetInt32(3) };
                        vrsta_studija_lista.Add(VrstaStudija1);
                    }
                }

                reader.Close();
                connection.Close();
            }
            return vrsta_studija_lista;
        }

        //Inserting row in table in SQL
        public async Task InsertVrstaStudijaRepositoryAsync(VrstaStudija vrsta_studija1)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = " INSERT INTO vrsta_studija VALUES naziv = ' " + vrsta_studija1.naziv + " ',trajanje_studija = ' " + vrsta_studija1.trajanje_studija + " '; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        //Updateing row in table in SQL
        public async Task UpdateVrstaStudijaRepositoryAsync(VrstaStudija vrsta_studija1)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = " update vrsta_studija set naziv = ' " + vrsta_studija1.naziv + " ',trajanje_studija = ' " + vrsta_studija1.trajanje_studija + " ' where id = '" + vrsta_studija1.vrsta_studija_id + "'; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        //Deleting row in table in SQL
        public async Task DeleteVrstaStudijaRepositoryAsync(int id)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = " delete from vrsta_studija where vrsta_studija_id = '" + id + "'; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }
    }
}
