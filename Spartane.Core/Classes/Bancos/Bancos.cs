using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Bancos
{
    /// <summary>
    /// Bancos table
    /// </summary>
    public class Bancos: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Completo { get; set; }
        public string Codigo { get; set; }


    }
}

