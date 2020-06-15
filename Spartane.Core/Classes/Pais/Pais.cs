using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Pais
{
    /// <summary>
    /// Pais table
    /// </summary>
    public class Pais: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre_del_Pais { get; set; }
        public string Abreviatura { get; set; }
        public string Codigo { get; set; }


    }
}

