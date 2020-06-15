using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllTTUsuarios : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int TTUsuarios_idUsuario { get; set; }
        public string TTUsuarios_Nombre { get; set; }
        public string TTUsuarios_Clave_de_Acceso { get; set; }
        public string TTUsuarios_Contrasena { get; set; }
        public bool? TTUsuarios_Activo { get; set; }
        public int? TTUsuarios_idGrupoUsuarios { get; set; }

    }
}
