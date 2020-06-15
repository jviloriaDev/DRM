using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Interpretacion_Dificultad_de_Rutina_de_Ejercicios
{
    /// <summary>
    /// Interpretacion_Dificultad_de_Rutina_de_Ejercicios table
    /// </summary>
    public class Interpretacion_Dificultad_de_Rutina_de_Ejercicios: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

