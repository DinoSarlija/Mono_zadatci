using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Projekat.Model;
using Projekat.Service.Common;
using WebAPI.Models;
using Projekat.Common;
using AutoMapper;

namespace WebAPI.Controllers
{
    public class VrstaStudijaController : ApiController
    {
        protected IVrstaStudijaService vrsta_studija_Service { get; private set; }
        public VrstaStudijaController(IVrstaStudijaService vrsta_studija_Service)
        {
            this.vrsta_studija_Service = vrsta_studija_Service;
        }

        public List<VrstaStudija> vrsta_studija_lista = new List<VrstaStudija>();
        public List<VrstaStudijaRest> vrsta_studija_rest_list = new List<VrstaStudijaRest>();
        protected IMapper vrsta_studija_Mapper { get; private set; }
        


        // GET metoda (bez filter,sort,page argumenata)
        [HttpGet]
        [Route("api/Select")]
        public async Task<HttpResponseMessage> SelectAsync()
        {
            
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<VrstaStudija, VrstaStudijaRest>()
                );
            IMapper vrsta_studija_Mapper = config.CreateMapper();

            vrsta_studija_lista = await vrsta_studija_Service.SelectAllVrstaStudijaAsync();
            if (!vrsta_studija_lista.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            foreach (VrstaStudija studij in vrsta_studija_lista)
            {
                //Using automapper
                var studij_rest = vrsta_studija_Mapper.Map<VrstaStudijaRest>(studij);
                vrsta_studija_rest_list.Add(studij_rest);
            }
           
            return Request.CreateResponse(HttpStatusCode.OK, vrsta_studija_rest_list);
        }

        // GET metoda sa filter,sort,page
        [HttpGet]
        [Route("api/SelectAll")]
        public async Task<HttpResponseMessage> SelectAllVrstaStudijaAsync([FromUri] Filter filter,[FromUri] Sort sort, [FromUri] Page page)
        {
            //Initialize the mapper
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<VrstaStudija, VrstaStudijaRest>()
                );
            IMapper vrsta_studija_Mapper = config.CreateMapper();

            vrsta_studija_lista = await vrsta_studija_Service.SelectAllVrstaStudijaAsync(filter, sort, page);
            if (!vrsta_studija_lista.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            foreach (VrstaStudija studij in vrsta_studija_lista)
            {
                //Using automapper
                var studij_rest = vrsta_studija_Mapper.Map<VrstaStudijaRest>(studij);
                vrsta_studija_rest_list.Add(studij_rest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, vrsta_studija_rest_list);
        }

        [HttpGet]
        [Route("api/SelectById/{id}")]
        public async Task<HttpResponseMessage> SelectByIdVrstaStudijaAsync(Guid id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VrstaStudija, VrstaStudijaRest>();
            });
            IMapper vrsta_studija_Mapper = config.CreateMapper();

            vrsta_studija_lista = await vrsta_studija_Service.SelectByIdVrstaStudijaAsync(id);
            if (!vrsta_studija_lista.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            foreach (VrstaStudija vrsta_studija in vrsta_studija_lista)
            {
                VrstaStudijaRest vrsta_studija_rest = vrsta_studija_Mapper.Map<VrstaStudijaRest>(vrsta_studija);
                vrsta_studija_rest_list.Add(vrsta_studija_rest);
            }
            return Request.CreateResponse(HttpStatusCode.OK, vrsta_studija_rest_list);
        }


        // POST metoda (Insert)
        [HttpPost]
        [Route("api/InsertVrstaStudija")]
        public async Task<HttpResponseMessage> InsertVrstaStudijaAsync([FromBody] VrstaStudija vrsta_studija)
        {
            if (await vrsta_studija_Service.InsertVrstaStudijaAsync(vrsta_studija) & vrsta_studija.naziv != "")
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // PUT metoda (Update)
        [HttpPut]
        [Route("api/UpdateVrstaStudija")]
        public async Task<HttpResponseMessage> UpdateVrstaStudijaAsync([FromBody] VrstaStudija vrsta_studija)
        {
            if ((await vrsta_studija_Service.UpdateVrstaStudijaAsync(vrsta_studija)) & (vrsta_studija.naziv != ""))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE metoda ()
        [HttpDelete]
        [Route("api/DeleteVrstaStudija/{id}")]
        public async Task<HttpResponseMessage> DeleteVrstaStudijaAsync(Guid id)
        {
            if (!await vrsta_studija_Service.DeleteVrstaStudijaAsync(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
