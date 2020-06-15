using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallTTUsuarios_Complete : BaseEntity
    {
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string Clave_de_Acceso { get; set; }
        public string Contrasena { get; set; }
        public bool Activo { get; set; }
        public int idGrupoUsuarios { get; set; }

    }
}
