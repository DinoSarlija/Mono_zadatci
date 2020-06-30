using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Common
{
    public interface ISort
    {
        string OrderBy { get; set; }
        string Order { get; set; }
    }
}
