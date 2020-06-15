using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo
{
    /// <summary>
    /// Interpretacion_Frecuencia_cardiaca_en_Esfuerzo table
    /// </summary>
    public class Interpretacion_Frecuencia_cardiaca_en_Esfuerzo: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

