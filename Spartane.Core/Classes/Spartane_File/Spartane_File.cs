using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.TTArchivos;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Spartane_File
{
    /// <summary>
    /// Spartan_File table
    /// </summary>
    public class Spartane_File : BaseEntity
    {
        public int File_Id { get; set; }
        public string Description { get; set; }
        public int? File1 { get; set; }
        public int? File_Size { get; set; }
        public int? Object { get; set; }
        public int? User_Id { get; set; }
        public DateTime? Date_Time { get; set; }
        

        [ForeignKey("File1")]
        public virtual Spartane.Core.Classes.TTArchivos.TTArchivos File1_TTArchivos { get; set; }

    }

    public class Spartane_FileModel 
    {
        public int File_Id { get; set; }
        public string Description { get; set; }
        public int? File1 { get; set; }
        public int? File_Size { get; set; }
        public int? Object { get; set; }
        public int? User_Id { get; set; }
        public DateTime? Date_Time { get; set; }
        public byte[] File { set; get; }

        
        public virtual Spartane.Core.Classes.TTArchivos.TTArchivos File1_TTArchivos { get; set; }

    }
}

