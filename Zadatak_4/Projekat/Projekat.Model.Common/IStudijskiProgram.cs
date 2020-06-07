using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Model.Common
{
    public class IStudijskiProgram
    {
        public Guid studijksi_program_id { get; set; }
        public Guid vrsta_studija_id { get; set; }
        public string kolegij_id { get; set; }
        public int godina { get; set; }
        public int obavezni { get; set; }
    }
}
