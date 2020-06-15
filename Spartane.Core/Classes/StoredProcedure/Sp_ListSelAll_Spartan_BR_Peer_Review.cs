using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_BR_Peer_Review : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_BR_Peer_Review_Key_Peer_Review { get; set; }
        public int? Spartan_BR_Peer_Review_User_that_reviewed { get; set; }
        public string Spartan_BR_Peer_Review_User_that_reviewed_Name { get; set; }
        public string Spartan_BR_Peer_Review_Acceptance_Criteria { get; set; }
        public bool? Spartan_BR_Peer_Review_It_worked { get; set; }
        public int? Spartan_BR_Peer_Review_Rejection_reason { get; set; }
        public string Spartan_BR_Peer_Review_Rejection_reason_Description { get; set; }
        public string Spartan_BR_Peer_Review_Comments { get; set; }
        public int? Spartan_BR_Peer_Review_Evidence { get; set; }
        public string Spartan_BR_Peer_Review_Evidence_Nombre { get; set; }
        public int Spartan_BR_Peer_Review_Business_Rule { get; set; }

    }
}
