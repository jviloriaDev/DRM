using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Ejercicios;
using Spartane.Core.Classes.Equipamiento_para_Ejercicios;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios
{
    /// <summary>
    /// MS_Equipamiento_para_Ejercicios table
    /// </summary>
    public class MS_Equipamiento_para_Ejercicios: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Equipamento { get; set; }

        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Classes.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Equipamento")]
        public virtual Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios Equipamento_Equipamiento_para_Ejercicios { get; set; }

    }
}

