using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Domain.Entities;


namespace School.Domain.Entities
{
    public  class PaginacionResponse<T>
    {
        public List<T>? Datos { get; set; }
        public int PaginaActual { get; set; }
        public int TamañoPagina { get; set; }
        public int TotalRegistros{ get; set; }
        public int  TotalPaginas { get; set; }
        public Boolean  TieneAnterior{ get; set; }
        public Boolean TieneSiguiente { get; set; }

    }
}
