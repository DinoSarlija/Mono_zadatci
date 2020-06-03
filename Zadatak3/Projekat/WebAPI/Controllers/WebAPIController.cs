using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    public class WebAPIController : ApiController
    {
        public class Studij
        {
            public int vrsta_studija_id { get; set; }
            public string naziv { get; set; }
            public int trajanje_studija { get; set; }

            public Studij(int v_s_id, string n, int t_s)
            {
                vrsta_studija_id = v_s_id;
                naziv = n;
                trajanje_studija = t_s;
            }
        }

        List<Studij> studiji = new List<Studij>();


        [HttpGet]
        public HttpResponseMessage Select()
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
                        Studij Studij1 = new Studij(vrsta_studija_id, naziv, trajanje_studija);
                        studiji.Add(Studij1);

                    }
                }

                reader.Close();
                connection.Close();
                return Request.CreateResponse(HttpStatusCode.OK, studiji);
            }
        }



        [HttpPost]
        public HttpResponseMessage Insert([FromBody] Studij studij1)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = " INSERT INTO vrsta_studija VALUES naziv = ' " + studij1.naziv + " ',trajanje_studija = ' " + studij1.trajanje_studija + " '; ";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                

            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Update([FromBody] Studij studij1)
        {
            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = Fakultet; Integrated Security = True";
            string queryString = " update vrsta_studija set naziv = ' " + studij1.naziv + " ',trajanje_studija = ' " + studij1.trajanje_studija+ " ' where id = '" + studij1.vrsta_studija_id + "'; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();

                return Request.CreateResponse(HttpStatusCode.OK);
            }

        }
         

       [HttpDelete]
        public HttpResponseMessage Delete(int id)
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
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}