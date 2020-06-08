using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekat.Model.Common;

namespace Projekat.Model
{
    public class StudijskiProgram : IStudijskiProgram
    {
        public Guid studijksi_program_id { get; set; } 
        public Guid vrsta_studija_id { get; set; } 
        public string kolegij_id { get; set; } 
        public int godina { get; set; }
        public int obavezni { get; set; }
        public VrstaStudija vrsta_studija { get; set; }
    }
}
 
