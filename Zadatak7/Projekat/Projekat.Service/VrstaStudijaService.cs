using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;
using Projekat.Repository;
using Projekat.Repository.Common;
using Projekat.Service.Common;

namespace Projekat.Service
{
    public class VrstaStudijaService : IVrstaStudijaService
    {
        //public List<VrstaStudija> vrsta_studijia_lista = new List<VrstaStudija>();
        //VrstaStudijaRepository vrsta_studija_repository = new VrstaStudijaRepository();
        public VrstaStudijaService(IVrstaStudijaRepository vrsta_studija_repository) 
        {
            this.Vrsta_Studija_Repository = vrsta_studija_repository;
        }
        protected IVrstaStudijaRepository Vrsta_Studija_Repository { get; private set; }


        public async Task<List<VrstaStudija>> SelectVrstaStudijaServiceAsync()
        {
            return await Vrsta_Studija_Repository.SelectVrstaStudijaRepositoryAsync();
            
            //vrsta_studijia_lista = await vrsta_studija_repository.SelectVrstaStudijaRepositoryAsync();
            //return vrsta_studijia_lista;
        }

        public async Task InsertVrstaStudijaServiceAsync(VrstaStudija vrsta_studija1)
        {
            await Vrsta_Studija_Repository.InsertVrstaStudijaRepositoryAsync(vrsta_studija1);
            //await vrsta_studija_repository.InsertVrstaStudijaRepositoryAsync(vrsta_studija1);
        }


        public async Task UpdateVrstaStudijaServiceAsync(VrstaStudija vrsta_studija1)
        {
            await Vrsta_Studija_Repository.UpdateVrstaStudijaRepositoryAsync(vrsta_studija1);
            //await vrsta_studija_repository.UpdateVrstaStudijaRepositoryAsync(vrsta_studija1);
        }


        public async Task DeleteVrstaStudijaServiceAsync(int id)
        {
            await Vrsta_Studija_Repository.DeleteVrstaStudijaRepositoryAsync(id);
            //await vrsta_studija_repository.DeleteVrstaStudijaRepositoryAsync(id);
        }
    }
}
