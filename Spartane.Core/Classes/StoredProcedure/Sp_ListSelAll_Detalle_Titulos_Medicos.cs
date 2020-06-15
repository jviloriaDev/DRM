using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Titulos_Medicos : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Titulos_Medicos_Folio { get; set; }
        public int Detalle_Titulos_Medicos_Folio_Medicos { get; set; }
        public string Detalle_Titulos_Medicos_Nombre_del_Titulo { get; set; }
        public string Detalle_Titulos_Medicos_Institucion_Facultad { get; set; }
        public DateTime? Detalle_Titulos_Medicos_Fecha_de_Titulacion { get; set; }
        public int? Detalle_Titulos_Medicos_Titulo { get; set; }
        public string Detalle_Titulos_Medicos_Titulo_Nombre { get; set; }
        public string Detalle_Titulos_Medicos_Numero_de_Cedula { get; set; }
        public DateTime? Detalle_Titulos_Medicos_Fecha_de_Expedicion { get; set; }
        public int? Detalle_Titulos_Medicos_Cedula_Frente { get; set; }
        public string Detalle_Titulos_Medicos_Cedula_Frente_Nombre { get; set; }
        public int? Detalle_Titulos_Medicos_Cedula_Reverso { get; set; }
        public string Detalle_Titulos_Medicos_Cedula_Reverso_Nombre { get; set; }

    }
}
