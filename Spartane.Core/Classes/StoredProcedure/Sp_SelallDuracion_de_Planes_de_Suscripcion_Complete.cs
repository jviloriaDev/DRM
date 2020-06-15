using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDuracion_de_Planes_de_Suscripcion_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public int? Cantidad_en_Meses { get; set; }
        public int? Cantidad_en_Dias { get; set; }

    }
}
