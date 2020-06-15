using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Caracteristicas_Ingrediente_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Ingrediente { get; set; }
        public string Caracteristica_combo { get; set; }
        public string Descripcion_texto { get; set; }

    }
}
