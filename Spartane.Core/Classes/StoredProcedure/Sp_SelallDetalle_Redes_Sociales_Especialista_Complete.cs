using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Redes_Sociales_Especialista_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Especialistas { get; set; }
        public int? Red_Social { get; set; }
        public string Red_Social_Descripcion { get; set; }
        public string URL { get; set; }
        public bool? Principal { get; set; }

    }
}
