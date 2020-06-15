using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Condition_Operator
{
    public partial class Spartan_BR_Condition_OperatorMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>
    {
        public Spartan_BR_Condition_OperatorMap()
        {
            this.ToTable("Spartan_BR_Condition_Operator");
            this.HasKey(a => a.ConditionOperatorId);
            this.Ignore(a => a.Id);
        }
    }
}
