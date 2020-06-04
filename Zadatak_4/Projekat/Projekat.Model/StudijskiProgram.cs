using System;
using System.Collections.Generic;
using System.Text;

namespace Projekat.Model
{
    class StudijskiProgram
    {
        public Guid studijksi_program_id { get; set; } 
        public Guid vrsta_studija_id { get; set; } 
        public string kolegij_id { get; set; } 
        public int godina { get; set; }
        public int obvezni { get; set; }
        public VrstaStudija vrsta_studija { get; set; }
}
}
 
