using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;

namespace Projekat.Repository.Common
{
    public interface IVrstaStudijaRepository
    {
        Task<List<VrstaStudija>> SelectVrstaStudijaRepositoryAsync();

        Task InsertVrstaStudijaRepositoryAsync(VrstaStudija vrsta_studija1);

        Task UpdateVrstaStudijaRepositoryAsync(VrstaStudija vrsta_studija1);

        Task DeleteVrstaStudijaRepositoryAsync(int id);
    }
}
