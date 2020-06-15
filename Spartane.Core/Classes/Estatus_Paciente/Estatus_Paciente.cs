using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Estatus_Paciente
{
    /// <summary>
    /// Estatus_Paciente table
    /// </summary>
    public class Estatus_Paciente: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }


    }
}

