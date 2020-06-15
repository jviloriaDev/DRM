using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_File_Complete : BaseEntity
    {
        public int File_Id { get; set; }
        public string Description { get; set; }
        public int? File1 { get; set; }
        public string File1_Nombre { get; set; }
        public int? File_Size { get; set; }
        public int? Object { get; set; }
        public int? User_Id { get; set; }
        public DateTime? Date_Time { get; set; }

    }
}
