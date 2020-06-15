using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Condition
{
    public partial class Spartan_BR_ConditionMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Condition.Spartan_BR_Condition>
    {
        public Spartan_BR_ConditionMap()
        {
            this.ToTable("Spartan_BR_Condition");
            this.HasKey(a => a.ConditionId);
            this.Ignore(a => a.Id);
        }
    }
}
