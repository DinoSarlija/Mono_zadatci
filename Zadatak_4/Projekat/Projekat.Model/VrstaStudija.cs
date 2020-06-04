using System;
using System.Collections.Generic;
using System.Text;


namespace Projekat.Model
{
    class VrstaStudija
    {
        public Guid vrsta_studija_id { get; set; }
        public string naziv { get; set; }
        public int trajanje_studija { get; set; }
        public List<StudijskiProgram> studijski_prgram { get; set; }
    }
}
