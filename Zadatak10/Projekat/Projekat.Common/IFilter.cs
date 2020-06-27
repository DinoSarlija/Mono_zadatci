using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Common
{
    public interface IFilter
    {
        string naziv { get; set; }
        int trajanje_studija { get; set; }
    }
}
