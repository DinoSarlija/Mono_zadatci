using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;
using Projekat.Repository.Common;
using Projekat.Service.Common;
using Projekat.Common;

namespace Projekat.Service
{
    public class VrstaStudijaService : IVrstaStudijaService
    {
        protected IVrstaStudijaRepository vrsta_studija_Repository { get; private set; }
        public List<VrstaStudija> vrsta_studijia_lista = new List<VrstaStudija>();
        public VrstaStudijaService(IVrstaStudijaRepository vrsta_studija_Repository)
        {
            this.vrsta_studija_Repository = vrsta_studija_Repository;
        }        


        public async Task<List<VrstaStudija>> SelectAllVrstaStudijaAsync()
        {
            return await vrsta_studija_Repository.SelectAllVrstaStudijaAsync();
        }

        public async Task<List<VrstaStudija>> SelectByIdVrstaStudijaAsync(Guid id)
        {
            return await vrsta_studija_Repository.SelectByIdVrstaStudijaAsync(id);
        }


        public async Task<List<VrstaStudija>> SelectAllVrstaStudijaAsync(Filter filter, Sort sorts, Page page)
        {
            return await vrsta_studija_Repository.SelectAllVrstaStudijaAsync(filter, sorts, page);
        }


        public async Task<bool> InsertVrstaStudijaAsync(VrstaStudija vrsta_studija)
        {
            return await vrsta_studija_Repository.InsertVrstaStudijaAsync(vrsta_studija);
        }

        public async Task<bool> UpdateVrstaStudijaAsync(VrstaStudija vrsta_studija)
        {
            return await vrsta_studija_Repository.UpdateVrstaStudijaAsync(vrsta_studija);
        }

        public async Task<bool> DeleteVrstaStudijaAsync(Guid id)
        {
            return await vrsta_studija_Repository.DeleteVrstaStudijaAsync(id);
        }
    }
}
