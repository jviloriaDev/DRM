using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Pais;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estado
{
    /// <summary>
    /// Estado table
    /// </summary>
    public class Estado: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre_del_Estado { get; set; }
        public int? Folio_Pais { get; set; }

        [ForeignKey("Folio_Pais")]
        public virtual Spartane.Core.Classes.Pais.Pais Folio_Pais_Pais { get; set; }

    }
}

