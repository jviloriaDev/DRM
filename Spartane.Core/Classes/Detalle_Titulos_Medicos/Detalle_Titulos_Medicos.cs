using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Medicos;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartane_File;
using Spartane.Core.Classes.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Titulos_Medicos
{
    /// <summary>
    /// Detalle_Titulos_Medicos table
    /// </summary>
    public class Detalle_Titulos_Medicos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Medicos { get; set; }
        public string Nombre_del_Titulo { get; set; }
        public string Institucion_Facultad { get; set; }
        public DateTime? Fecha_de_Titulacion { get; set; }
        public int? Titulo { get; set; }
        //public string Titulo_URL { get; set; }
        public string Numero_de_Cedula { get; set; }
        public DateTime? Fecha_de_Expedicion { get; set; }
        public int? Cedula_Frente { get; set; }
        //public string Cedula_Frente_URL { get; set; }
        public int? Cedula_Reverso { get; set; }
        //public string Cedula_Reverso_URL { get; set; }

        [ForeignKey("Folio_Medicos")]
        public virtual Spartane.Core.Classes.Medicos.Medicos Folio_Medicos_Medicos { get; set; }
        [ForeignKey("Titulo")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Titulo_Spartane_File { get; set; }
        [ForeignKey("Cedula_Frente")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Cedula_Frente_Spartane_File { get; set; }
        [ForeignKey("Cedula_Reverso")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Cedula_Reverso_Spartane_File { get; set; }

    }
}

