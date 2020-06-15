using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_pantalla_Francisco
{
    /// <summary>
    /// Detalle_pantalla_Francisco table
    /// </summary>
    public class Detalle_pantalla_Francisco: BaseEntity
    {
        public int Folio { get; set; }
        public int? Archivo { get; set; }
        //public string Archivo_URL { get; set; }
        public string Campo { get; set; }

        [ForeignKey("Archivo")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Archivo_Spartane_File { get; set; }

    }
}

