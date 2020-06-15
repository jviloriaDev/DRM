using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estatus_Actividades_Evento
{
    /// <summary>
    /// Estatus_Actividades_Evento table
    /// </summary>
    public class Estatus_Actividades_Evento: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

