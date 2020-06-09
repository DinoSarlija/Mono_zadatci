using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projekat.Model;
using Projekat.Service;
using Projekat.Service.Common;
using AutoMapper;
using System.Threading.Tasks;
using System.Drawing.Text;

namespace Projekat.WebAPI.Controllers
{
    public class WebAPIController : ApiController
    {
        // List of VrstaStudija with all data
        public List<VrstaStudija> vrsta_studija_lista = new List<VrstaStudija>();
        // List of VrstaStudija with some data by automapper
        public List<MappedVrstaStudija> Mvrsta_studija_lista = new List<MappedVrstaStudija>();



        VrstaStudijaService vrsta_studija_service = new VrstaStudijaService();



        // GET metoda (Select)
        [HttpGet]
        [Route("api/Select")]
        public async Task<HttpResponseMessage> SelectAsync()
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<VrstaStudija, MappedVrstaStudija>()
                );

            vrsta_studija_lista = await vrsta_studija_service.SelectVrstaStudijaServiceAsync();
            foreach (VrstaStudija studij in vrsta_studija_lista)
            {
                //Using automapper
                var mapper = new Mapper(config);
                var Mstudij = mapper.Map<MappedVrstaStudija>(studij);
                Mvrsta_studija_lista.Add(Mstudij);
            }
            return Request.CreateResponse(HttpStatusCode.OK, Mvrsta_studija_lista);
        }

        // POST metoda (Insert)
        [HttpPost]
        [Route("api/Insert")]
        public async Task<HttpResponseMessage> InsertAsync([FromBody] VrstaStudija vrsta_studija1)
        {
            await vrsta_studija_service.InsertVrstaStudijaServiceAsync(vrsta_studija1);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT metoda (Update)
        [HttpPut]
        [Route("api/Update")]
        public async Task<HttpResponseMessage> UpdateAsync([FromBody] VrstaStudija vrsta_studija1)
        {
            await vrsta_studija_service.UpdateVrstaStudijaServiceAsync(vrsta_studija1);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE metoda ()
        [HttpDelete]
        [Route("api/Delete")]
        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            await vrsta_studija_service.DeleteVrstaStudijaServiceAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
