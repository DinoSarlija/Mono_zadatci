using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Model;

namespace Projekat.Service.Common
{
    public interface IVrstaStudijaService
    {
        public List<VrstaStudija> SelectVrstaStudijaService();

        void InsertVrstaStudijaService(VrstaStudija vrsta_studija1);

        void UpdateVrstaStudijaService(VrstaStudija vrsta_studija1);

        void DeleteVrstaStudijaService(int id);
    }
}
