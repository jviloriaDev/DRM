using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estatus_Llamadas
{
    /// <summary>
    /// Estatus_Llamadas table
    /// </summary>
    public class Estatus_Llamadas: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

