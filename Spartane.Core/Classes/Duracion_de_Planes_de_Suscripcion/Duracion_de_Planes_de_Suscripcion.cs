using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Duracion_de_Planes_de_Suscripcion
{
    /// <summary>
    /// Duracion_de_Planes_de_Suscripcion table
    /// </summary>
    public class Duracion_de_Planes_de_Suscripcion: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public int? Cantidad_en_Meses { get; set; }
        public int? Cantidad_en_Dias { get; set; }


    }
}

