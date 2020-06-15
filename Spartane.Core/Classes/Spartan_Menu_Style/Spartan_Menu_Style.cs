using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Menu_Style
{
    /// <summary>
    /// Spartan_Menu_Style table
    /// </summary>
    public class Spartan_Menu_Style: BaseEntity
    {
        public short Menu_Style_Id { get; set; }
        public string Description { get; set; }


    }
}

