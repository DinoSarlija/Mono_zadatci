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
        public class VrstaStudija
        {
            public int vrsta_studija_id { get; set; }
            public string naziv { get; set; }
            public int trajanje_studija { get; set; }

            public VrstaStudija(int v_s_id, string n, int t_s)
            {
                vrsta_studija_id = v_s_id;
                naziv = n;
                trajanje_studija = t_s;
            }
        }

        List<VrstaStudija> studiji = new List<VrstaStudija>();

        [HttpGet]
        public HttpResponseMessage Select()
        {
           
            return Request.CreateResponse(HttpStatusCode.OK, studiji);
        }

        [HttpPost]
        public HttpResponseMessage Insert([FromBody] VrstaStudija studij1)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        public HttpResponseMessage Update([FromBody] VrstaStudija studij1)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }
         
       [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}