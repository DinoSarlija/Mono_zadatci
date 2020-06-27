using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Common
{
    public class Page : IPage
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
