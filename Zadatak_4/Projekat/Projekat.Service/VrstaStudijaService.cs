using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Projekat.Model;


namespace Projekat.Service
{
    class VrstaStudijaService
    {
        List<VrstaStudija> vrsta_studijia = new List<VrstaStudija>();
        public void SelectVrstaStudijaService()
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
                        int vrsta_studija_id = reader.GetInt32(0);
                        string naziv = reader.GetString(1);
                        int trajanje_studija = reader.GetInt32(3);
                        VrstaStudija VrstaStudija1 = new vrsta_studijia(vrsta_studija_id, naziv, trajanje_studija);
                        vrsta_studijia.Add(VrstaStudija1);
                    }
                }
                reader.Close();
                connection.Close();
            }
        }

        public void InsertVrstaStudijaService(VrstaStudija vrsta_studijia1)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = " INSERT INTO vrsta_studija VALUES naziv = ' " + vrsta_studijia1.naziv + " ',trajanje_studija = ' " + studij1.trajanje_studija + " '; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        public void UpdateVrstaStudijaService(VrstaStudija vrsta_studijia1)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = " update vrsta_studija set naziv = ' " + vrsta_studijia.naziv + " ',trajanje_studija = ' " + vrsta_studijia1.trajanje_studija + " ' where id = '" + vrsta_studijia1.vrsta_studija_id + "'; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        public void DeleteVrstaStudijaService(int id)
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
