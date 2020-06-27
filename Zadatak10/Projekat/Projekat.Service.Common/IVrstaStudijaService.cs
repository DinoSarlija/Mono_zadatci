using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model;
using Projekat.Common;

namespace Projekat.Service.Common
{
    public interface IVrstaStudijaService
    {
        Task<List<VrstaStudija>> SelectAllVrstaStudijaAsync();
        Task<List<VrstaStudija>> SelectAllVrstaStudijaAsync(Filter filter, Sort sorts, Page page);
        Task<List<VrstaStudija>> SelectByIdVrstaStudijaAsync(Guid id);

        Task<bool> InsertVrstaStudijaAsync(VrstaStudija vrsta_studija);
        Task<bool> UpdateVrstaStudijaAsync(VrstaStudija vrsta_studija);
        Task<bool> DeleteVrstaStudijaAsync(Guid id);
    }
}
