using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_Condition
{
    public partial class Spartan_WorkFlow_ConditionMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition>
    {
        public Spartan_WorkFlow_ConditionMap()
        {
            this.ToTable("Spartan_WorkFlow_Condition");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.ConditionId);
        }
    }
}
