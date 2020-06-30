using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model.Common;

namespace Projekat.Model
{
    public class VrstaStudija : IVrstaStudija
    {
        public Guid id { get; set; }
        public string naziv { get; set; }
        public int trajanje_studija { get; set; }
    }
}
