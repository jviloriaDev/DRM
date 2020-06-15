using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallEstado_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre_del_Estado { get; set; }
        public int? Folio_Pais { get; set; }
        public string Folio_Pais_Nombre_del_Pais { get; set; }

    }
}
