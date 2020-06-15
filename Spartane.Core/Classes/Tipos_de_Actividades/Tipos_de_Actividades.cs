using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Tipos_de_Actividades
{
    /// <summary>
    /// Tipos_de_Actividades table
    /// </summary>
    public class Tipos_de_Actividades: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

