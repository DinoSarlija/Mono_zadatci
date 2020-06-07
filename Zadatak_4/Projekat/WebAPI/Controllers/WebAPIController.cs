using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Projekat.Model;
using Projekat.Service;
using AutoMapper;


namespace WebAPI.Controllers
{
    public class MVrstaSrudija
    {
        public string naziv { get; set; }
        public int trajanje_studija { get; set; }
    }
    public class WebAPIController : ApiController
    {
        // List of VrstaStudija with all data
        public List<VrstaStudija> vrsta_studija_lista = new List<VrstaStudija>();
        // List of VrstaStudija with some data by automapper
        public List<MVrstaStudija> Mvrsta_studija_lista = new List<MVrstaStudija>();

        Projekat.Service.VrstaStudijaServices vrsta_studija_service = new Projekat.Service.VrstaStudijaService();

        //Initialize the mapper
        var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<VrstaStudija, MVrstaStudija>()
            );


        // GET metoda (Select)
        [HttpGet]
        [Route("api/Select")]
        public HttpResponseMessage Select()
        {
            vrsta_studija_lista = vrsta_studija_service.SelectVrstaStudijaService();
            foreach(VrstaStudija studij in vrsta_studija_lista)
            {
                //Using automapper
                var mapper = new Mapper(config);
                var Mstudij = mapper.Map<MVrstaSrudija>(studij);
                Mvrsta_studija_lista.Add(Mstudij);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Mvrsta_studija_lista);
        }

        // POST metoda (Insert)
        [HttpPost]
        [Route("api/Insert")]
        public HttpResponseMessage Insert([FromBody] VrstaStudija vrsta_studija1)
        {
            vrsta_studija_service.InsertVrstaStudijaService(vrsta_studija1);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT metoda (Update)
        [HttpPut]
        [Route("api/Update")]
        public HttpResponseMessage Update([FromBody] VrstaStudija vrsta_studija1)
        {
            vrsta_studija_service.UpdateVrstaStudijaService(vrsta_studija1);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        // DELETE metoda ()
        [HttpDelete]
        [Route("api/Delete")]
        public HttpResponseMessage Delete(int id)
        {
            vrsta_studija_service.DeleteVrstaStudijaService(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}