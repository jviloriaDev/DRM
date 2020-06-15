using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Equipamiento_para_Ejercicios
{
    /// <summary>
    /// Equipamiento_para_Ejercicios table
    /// </summary>
    public class Equipamiento_para_Ejercicios: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

