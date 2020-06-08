using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Model.Common
{
    public interface IVrstaStudija
    {
        Guid vrsta_studija_id { get; set; }
        string naziv { get; set; }
        int trajanje_studija { get; set; }
    }
}
