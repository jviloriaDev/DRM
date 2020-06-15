using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Ejercicios;
using Spartane.Core.Classes.Musculos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.MS_Musculos
{
    /// <summary>
    /// MS_Musculos table
    /// </summary>
    public class MS_Musculos: BaseEntity
    {
        public int Folio { get; set; }
        public int? Folio_Ejercicios { get; set; }
        public int? Musculo { get; set; }

        [ForeignKey("Folio_Ejercicios")]
        public virtual Spartane.Core.Classes.Ejercicios.Ejercicios Folio_Ejercicios_Ejercicios { get; set; }
        [ForeignKey("Musculo")]
        public virtual Spartane.Core.Classes.Musculos.Musculos Musculo_Musculos { get; set; }

    }
}

