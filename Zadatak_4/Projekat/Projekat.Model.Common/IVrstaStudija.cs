using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Model.Common
{
    public class IVrstaStudija
    {
        public Guid vrsta_studija_id { get; set; }
        public string naziv { get; set; }
        public int trajanje_studija { get; set; }
    }
}
