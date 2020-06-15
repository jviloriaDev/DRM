using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Spartane_File;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartan_System
{
    /// <summary>
    /// Spartan_System table
    /// </summary>
    public class Spartan_System: BaseEntity
    {
        public short System_Id { get; set; }
        public string Version { get; set; }
        public int? System_Image { get; set; }
        public int? Customer_Image { get; set; }
        public int? Developer_Image { get; set; }

        [ForeignKey("System_Image")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File System_Image_Spartane_File { get; set; }
        [ForeignKey("Customer_Image")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Customer_Image_Spartane_File { get; set; }
        [ForeignKey("Developer_Image")]
        public virtual Spartane.Core.Classes.Spartane_File.Spartane_File Developer_Image_Spartane_File { get; set; }

    }
}

