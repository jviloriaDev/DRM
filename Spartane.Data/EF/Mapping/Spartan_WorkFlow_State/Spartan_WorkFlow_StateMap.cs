using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_State
{
    public partial class Spartan_WorkFlow_StateMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_State.Spartan_WorkFlow_State>
    {
        public Spartan_WorkFlow_StateMap()
        {
            this.ToTable("Spartan_WorkFlow_State");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.StateId);
        }
    }
}
