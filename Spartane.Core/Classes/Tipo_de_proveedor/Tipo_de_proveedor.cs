using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipo_de_proveedor
{
    /// <summary>
    /// Tipo_de_proveedor table
    /// </summary>
    public class Tipo_de_proveedor: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

