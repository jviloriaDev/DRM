using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallSpartan_User_Complete : BaseEntity
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public int? Role { get; set; }
        public string Role_Description { get; set; }
        public int? Image { get; set; }
        public string Image_Description { get; set; }
        public string Email { get; set; }
        public int? Status { get; set; }
        public string Status_Description { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
