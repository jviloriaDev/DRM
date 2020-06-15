using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallTiempos_de_Comida_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Comida { get; set; }
        public string Hora_min { get; set; }
        public string Hora_max { get; set; }
        public int? Pais { get; set; }
        public string Pais_Nombre_del_Pais { get; set; }

    }
}
