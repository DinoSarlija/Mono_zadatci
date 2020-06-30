using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;
using Projekat.Common;

namespace Projekat.Repository.Common
{
    public interface IVrstaStudijaRepository
    {
        Task<List<VrstaStudija>> SelectVrstaStudijaAsync();
        Task<List<VrstaStudija>> SelectAllVrstaStudijaAsync(Filter filter, Sort sorts, Page page);
        Task<List<VrstaStudija>> SelectByIdVrstaStudijaAsync(Guid id);
        Task<bool> InsertVrstaStudijaAsync(VrstaStudija vrsta_studija);
        Task<bool> UpdateVrstaStudijaAsync(VrstaStudija vrsta_studija, Guid Id);
        Task<bool> DeleteVrstaStudijaAsync(Guid Id);
    }
}
