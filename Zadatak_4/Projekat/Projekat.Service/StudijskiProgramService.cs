using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Projekat.Model;

namespace Projekat.Service
{
    public class StudijskiProgramService
    {
        List<StudijskiProgram> studiji = new List<StudijskiProgram>();
        public void  SelectStudijskiProgramService()
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = "select studijksi_program_id, vrsta_studija_id, kolegij_id, godina, obavezni from studijski_program;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int studijksi_program_id = reader.GetInt32(0);
                        int vrsta_studija_id = reader.GetInt32(1);
                        string kolegij_id = reader.GetString(2);
                        int godina = reader.GetString(3);
                        int obavezni = reader.GetInt32(4);
                        StudijskiProgram StudijskiProgram1 = new StudijskiProgram(studijksi_program_id, vrsta_studija_id, kolegij_id, godina, obavezni);
                        studiji.Add(StudijskiProgram1);
                    }
                }
                reader.Close();
                connection.Close();
            }
        }

        public void InsertStudijskiProgramService(StudijskiProgram studij1)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = " INSERT INTO studijksi_program VALUES vrsta_studija_id = ' " + studij1.vrsta_studija_id + " ' ,kolegij_id = ' " + studij1.kolegij_id + " ',godina = ' " + studij1.godina + " ',obavezni = ' " + studij1.obavezni + " ; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        public void UpdateStudijskiProgramService(StudijskiProgram studij1)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = " update studijksi_program set vrsta_studija_id = ' " + studij1.vrsta_studija_id + " ' ,kolegij_id = ' " + studij1.kolegij_id + " ',godina = ' " + studij1.godina + " ',obavezni = ' " + studij1.obavezni + " ' where id = '" + studij1.studijksi_program_id + "'; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
            }
        }

        public void DeleteStudijskiProgramService(int id)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = " delete from studijksi_program where vrsta_studija_id = '" + id + "'; ";

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
