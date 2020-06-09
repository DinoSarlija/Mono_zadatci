using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;

namespace Projekat.Service.Common
{
    public interface IVrstaStudijaService
    {
        Task<List<VrstaStudija>> SelectVrstaStudijaServiceAsync();

        Task InsertVrstaStudijaServiceAsync(VrstaStudija vrsta_studija1);

        Task UpdateVrstaStudijaServiceAsync(VrstaStudija vrsta_studija1);

        Task DeleteVrstaStudijaServiceAsync(int id);
    }
}
