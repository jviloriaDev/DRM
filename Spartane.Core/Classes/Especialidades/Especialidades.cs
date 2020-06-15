using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Profesiones;
using Spartane.Core.Classes.Estatus;
using Spartane.Core.Classes.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Especialidades
{
    /// <summary>
    /// Especialidades table
    /// </summary>
    public class Especialidades: BaseEntity
    {
        public int Clave { get; set; }
        public string Especialidad { get; set; }
        public int? Profesion { get; set; }
        public int? Estatus { get; set; }
        public int? Imagen { get; set; }
        //public string Imagen_URL { get; set; }

        [ForeignKey("Profesion")]
        public virtual Spartane.Core.Classes.Profesiones.Profesiones Profesion_Profesiones { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }
        [ForeignKey("Imagen")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Imagen_Spartane_File { get; set; }

    }
}

