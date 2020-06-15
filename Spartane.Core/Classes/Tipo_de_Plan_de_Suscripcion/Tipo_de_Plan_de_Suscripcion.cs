using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipo_de_Plan_de_Suscripcion
{
    /// <summary>
    /// Tipo_de_Plan_de_Suscripcion table
    /// </summary>
    public class Tipo_de_Plan_de_Suscripcion: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }


    }
}

