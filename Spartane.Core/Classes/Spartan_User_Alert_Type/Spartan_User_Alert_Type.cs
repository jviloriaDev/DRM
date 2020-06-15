using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_User_Alert_Type
{
    /// <summary>
    /// Spartan_User_Alert_Type table
    /// </summary>
    public class Spartan_User_Alert_Type: BaseEntity
    {
        public short User_Alert_Type_Id { get; set; }
        public string Description { get; set; }
        public int? Image { get; set; }

        [ForeignKey("Image")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Image_Spartane_File { get; set; }

    }
}

