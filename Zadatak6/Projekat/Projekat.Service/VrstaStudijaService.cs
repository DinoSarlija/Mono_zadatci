using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;
using Projekat.Repository;
using Projekat.Service.Common;

namespace Projekat.Service
{
    public class VrstaStudijaService : IVrstaStudijaService
    {
        public List<VrstaStudija> vrsta_studijia_lista = new List<VrstaStudija>();
        VrstaStudijaRepository vrsta_studija_repository = new VrstaStudijaRepository();
        public VrstaStudijaService() { }

        public async Task<List<VrstaStudija>> SelectVrstaStudijaServiceAsync()
        {
            vrsta_studijia_lista = await vrsta_studija_repository.SelectVrstaStudijaRepositoryAsync();
            return vrsta_studijia_lista;
        }

        public async Task InsertVrstaStudijaServiceAsync(VrstaStudija vrsta_studija1)
        {
            await vrsta_studija_repository.InsertVrstaStudijaRepositoryAsync(vrsta_studija1);
        }


        public async Task UpdateVrstaStudijaServiceAsync(VrstaStudija vrsta_studija1)
        {
            await vrsta_studija_repository.UpdateVrstaStudijaRepositoryAsync(vrsta_studija1);
        }


        public async Task DeleteVrstaStudijaServiceAsync(int id)
        {
            await vrsta_studija_repository.DeleteVrstaStudijaRepositoryAsync(id);
        }
    }
}
