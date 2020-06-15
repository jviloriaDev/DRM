using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Planes_Alimenticios_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Planes_Alimenticios { get; set; }
        public int? Tiempo_de_Comida { get; set; }
        public string Tiempo_de_Comida_Comida { get; set; }
        public int? Numero_de_Dia { get; set; }
        public string Numero_de_Dia_Dia { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Platillo { get; set; }
        public string Platillo_Nombre_de_Platillo { get; set; }
        public bool? Modificado { get; set; }

    }
}
