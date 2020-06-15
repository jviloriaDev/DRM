using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Action
{
    public partial class Spartan_BR_ActionMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Action.Spartan_BR_Action>
    {
        public Spartan_BR_ActionMap()
        {
            this.ToTable("Spartan_BR_Action");
            this.HasKey(a => a.ActionId);
            this.Ignore(a => a.Id);
        }
    }
}
