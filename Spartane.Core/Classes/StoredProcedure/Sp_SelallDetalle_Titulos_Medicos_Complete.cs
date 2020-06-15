using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Titulos_Medicos_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Folio_Medicos { get; set; }
        public string Nombre_del_Titulo { get; set; }
        public string Institucion_Facultad { get; set; }
        public DateTime? Fecha_de_Titulacion { get; set; }
        public int? Titulo { get; set; }
        public string Numero_de_Cedula { get; set; }
        public DateTime? Fecha_de_Expedicion { get; set; }
        public int? Cedula_Frente { get; set; }
        public int? Cedula_Reverso { get; set; }

    }
}
