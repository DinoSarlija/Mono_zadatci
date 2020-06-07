using System;
using System.Collections.Generic;
using System.Text;
using Projekat.Model;

namespace Projekat.Repository.Common
{
    public interface IVrstaStudijaRepository
    {

        List<VrstaStudija> SelectVrstaStudijaRepository();

        void InsertVrstaStudijaRepository(VrstaStudija vrsta_studija1);

        void UpdateVrstaStudijaRepository(VrstaStudija vrsta_studija1);

        void DeleteVrstaStudijaRepository(int id);
    }
}
