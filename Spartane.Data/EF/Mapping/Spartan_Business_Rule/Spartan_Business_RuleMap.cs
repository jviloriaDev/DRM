using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Business_Rule
{
    public partial class Spartan_Business_RuleMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Business_Rule.Spartan_Business_Rule>
    {
        public Spartan_Business_RuleMap()
        {
            this.ToTable("Spartan_Business_Rule");
            this.HasKey(a => a.BusinessRuleId);
            this.Ignore(a => a.Id);
        }
    }
}
