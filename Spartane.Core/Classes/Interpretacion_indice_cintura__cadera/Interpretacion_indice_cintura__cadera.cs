using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Interpretacion_indice_cintura__cadera
{
    /// <summary>
    /// Interpretacion_indice_cintura__cadera table
    /// </summary>
    public class Interpretacion_indice_cintura__cadera: BaseEntity
    {
        public int Folio { get; set; }
        public string Descripcion { get; set; }


    }
}

