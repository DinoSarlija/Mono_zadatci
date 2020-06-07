using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Data.SqlClient;
using Projekat.Model;
using Projekat.Repository;
using Projekat.Service.Common;


namespace Projekat.Service
{
    public class VrstaStudijaService : IVrstaStudijaService
    {
        public List<VrstaStudija> vrsta_studijia_lista = new List<VrstaStudija>();
        Projekat.Repository.VrstaStudijaRepository vrsta_studija_repository = new Projekat.Repository.VrstaStudijaRepository();
        public VrstaStudijaService() { }

        public List<VrstaStudija> SelectVrstaStudijaService()
        {
            vrsta_studijia_lista = vrsta_studija_repository.SelectVrstaStudijaRepository();
            return vrsta_studijia_lista;
        }

        public void InsertVrstaStudijaService(VrstaStudija vrsta_studija1)
        {
            vrsta_studija_repository.InsertVrstaStudijaRepository(vrsta_studija1);
        }


        public void UpdateVrstaStudijaService(VrstaStudija vrsta_studija1)
        {
            vrsta_studija_repository.UpdateVrstaStudijaRepository(vrsta_studija1);
        }


        public void DeleteVrstaStudijaService(int id)
        {
            vrsta_studija_repository.DeleteVrstaStudijaRepository(id);
        }
    }
}
