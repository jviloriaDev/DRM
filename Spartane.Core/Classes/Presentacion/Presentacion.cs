using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Presentacion
{
    /// <summary>
    /// Presentacion table
    /// </summary>
    public class Presentacion: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

