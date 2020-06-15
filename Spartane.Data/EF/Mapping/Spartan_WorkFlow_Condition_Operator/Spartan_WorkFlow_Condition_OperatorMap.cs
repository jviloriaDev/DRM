using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_WorkFlow_Condition_Operator
{
    public partial class Spartan_WorkFlow_Condition_OperatorMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_WorkFlow_Condition_Operator.Spartan_WorkFlow_Condition_Operator>
    {
        public Spartan_WorkFlow_Condition_OperatorMap()
        {
            this.ToTable("Spartan_WorkFlow_Condition_Operator");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Condition_OperatorId);
        }
    }
}
