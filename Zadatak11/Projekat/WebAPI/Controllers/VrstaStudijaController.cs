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
        protected IMapper vrsta_studija_Mapper { get; private set; }
        public VrstaStudijaController(IVrstaStudijaService vrsta_studija_Service,IMapper mapper_vrsta_studija)
        {
            this.vrsta_studija_Service = vrsta_studija_Service;
            this.vrsta_studija_Mapper = mapper_vrsta_studija;
        }

        public List<VrstaStudija> Vrsta_studija_lista = new List<VrstaStudija>();
        public List<VrstaStudijaRest> Vrsta_studija_rest_list = new List<VrstaStudijaRest>();
        



        // GET metoda (bez filter,sort,page argumenata)
        [HttpGet]
        [Route("api/Select")]
        public async Task<HttpResponseMessage> SelectAsync()
        {
            Vrsta_studija_lista = await vrsta_studija_Service.SelectVrstaStudijaAsync();
            if (!Vrsta_studija_lista.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Vrsta_studija_rest_list = vrsta_studija_Mapper.Map<List<VrstaStudijaRest>>(Vrsta_studija_lista);

            return Request.CreateResponse(HttpStatusCode.OK, Vrsta_studija_lista);//Vrsta_studija_rest_list);
        }

        // GET metoda sa filter,sort,page
        [HttpGet]
        [Route("api/SelectAll")]
        public async Task<HttpResponseMessage> SelectAllVrstaStudijaAsync([FromUri] Filter filter,[FromUri] Sort sort, [FromUri] Page page)
        {
            Vrsta_studija_lista = await vrsta_studija_Service.SelectAllVrstaStudijaAsync(filter, sort, page);
            if (!Vrsta_studija_lista.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Vrsta_studija_rest_list = vrsta_studija_Mapper.Map<List<VrstaStudijaRest>>(Vrsta_studija_lista);

            return Request.CreateResponse(HttpStatusCode.OK, Vrsta_studija_rest_list);
        }

        [HttpGet]
        [Route("api/SelectById/{id}")]
        public async Task<HttpResponseMessage> SelectByIdVrstaStudijaAsync(Guid Id)
        {
            Vrsta_studija_lista = await vrsta_studija_Service.SelectByIdVrstaStudijaAsync(Id);
            if (!Vrsta_studija_lista.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Vrsta_studija_rest_list = vrsta_studija_Mapper.Map<List<VrstaStudijaRest>>(Vrsta_studija_lista);
            
            return Request.CreateResponse(HttpStatusCode.OK, Vrsta_studija_rest_list);
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
        public async Task<HttpResponseMessage> UpdateVrstaStudijaAsync([FromBody] VrstaStudija vrsta_studija,[FromUri] Guid Id)
        {
            if ((await vrsta_studija_Service.UpdateVrstaStudijaAsync(vrsta_studija,Id)) & (vrsta_studija.naziv != ""))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        // DELETE metoda ()
        [HttpDelete]
        [Route("api/DeleteVrstaStudija/{Id}")]
        public async Task<HttpResponseMessage> DeleteVrstaStudijaAsync(Guid Id)
        {
            if (!await vrsta_studija_Service.DeleteVrstaStudijaAsync(Id))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}
