using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallEspecialidades_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Especialidad { get; set; }
        public int? Profesion { get; set; }
        public string Profesion_Descripcion { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public int? Imagen { get; set; }

    }
}
