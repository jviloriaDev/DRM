using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Notice_Type
{
    /// <summary>
    /// Spartan_Notice_Type table
    /// </summary>
    public class Spartan_Notice_Type: BaseEntity
    {
        public int Notice_Type_Id { get; set; }
        public string Description { get; set; }


    }
}

