using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Common
{
    public class Filter : IFilter
    {
        public string naziv { get; set; }
        public int trajanje_studija { get; set; }
    }
}
