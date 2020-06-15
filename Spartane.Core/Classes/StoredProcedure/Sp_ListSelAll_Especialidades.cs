using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllEspecialidades : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Especialidades_Clave { get; set; }
        public string Especialidades_Especialidad { get; set; }
        public int? Especialidades_Profesion { get; set; }
        public string Especialidades_Profesion_Descripcion { get; set; }
        public int? Especialidades_Estatus { get; set; }
        public string Especialidades_Estatus_Descripcion { get; set; }
        public int? Especialidades_Imagen { get; set; }
        public string Especialidades_Imagen_Nombre { get; set; }

    }
}
