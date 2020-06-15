using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_Menu_Orientation
{
    /// <summary>
    /// Spartan_Menu_Orientation table
    /// </summary>
    public class Spartan_Menu_Orientation: BaseEntity
    {
        public short System_Menu_Orientation_Id { get; set; }
        public string Description { get; set; }


    }
}

