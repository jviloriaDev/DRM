using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipo_Modificacion_Alimentos
{
    /// <summary>
    /// Tipo_Modificacion_Alimentos table
    /// </summary>
    public class Tipo_Modificacion_Alimentos: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

