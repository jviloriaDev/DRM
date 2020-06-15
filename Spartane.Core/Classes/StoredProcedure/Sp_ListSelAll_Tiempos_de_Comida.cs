using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTiempos_de_Comida : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Tiempos_de_Comida_Clave { get; set; }
        public string Tiempos_de_Comida_Comida { get; set; }
        public string Tiempos_de_Comida_Hora_min { get; set; }
        public string Tiempos_de_Comida_Hora_max { get; set; }
        public int? Tiempos_de_Comida_Pais { get; set; }
        public string Tiempos_de_Comida_Pais_Nombre_del_Pais { get; set; }

    }
}
