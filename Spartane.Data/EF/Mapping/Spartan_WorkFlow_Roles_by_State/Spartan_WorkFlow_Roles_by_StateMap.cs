using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_Roles_by_State
{
    public partial class Spartan_WorkFlow_Roles_by_StateMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>
    {
        public Spartan_WorkFlow_Roles_by_StateMap()
        {
            this.ToTable("Spartan_WorkFlow_Roles_by_State");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Roles_by_StateId);
        }
    }
}
