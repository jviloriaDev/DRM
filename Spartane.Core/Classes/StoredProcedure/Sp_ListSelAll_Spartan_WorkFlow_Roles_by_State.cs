using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllSpartan_WorkFlow_Roles_by_State : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Spartan_WorkFlow_Roles_by_State_Spartan_WorkFlow { get; set; }
        public int Spartan_WorkFlow_Roles_by_State_Roles_by_StateId { get; set; }
        public int? Spartan_WorkFlow_Roles_by_State_Phase { get; set; }
        public string Spartan_WorkFlow_Roles_by_State_Phase_Name { get; set; }
        public int? Spartan_WorkFlow_Roles_by_State_State { get; set; }
        public string Spartan_WorkFlow_Roles_by_State_State_Name { get; set; }
        public short? Spartan_WorkFlow_Roles_by_State_User_Role { get; set; }
        public short? Spartan_WorkFlow_Roles_by_State_Phase_Transition { get; set; }
        public bool? Spartan_WorkFlow_Roles_by_State_Permission_To_Consult { get; set; }
        public bool? Spartan_WorkFlow_Roles_by_State_Permission_To_New { get; set; }
        public bool? Spartan_WorkFlow_Roles_by_State_Permission_To_Modify { get; set; }
        public bool? Spartan_WorkFlow_Roles_by_State_Permission_to_Delete { get; set; }
        public bool? Spartan_WorkFlow_Roles_by_State_Permission_To_Export { get; set; }
        public bool? Spartan_WorkFlow_Roles_by_State_Permission_To_Print { get; set; }
        public bool? Spartan_WorkFlow_Roles_by_State_Permission_Settings { get; set; }

    }
}
