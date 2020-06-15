using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Conditions_Detail
{
    public partial class Spartan_BR_Conditions_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Conditions_Detail.Spartan_BR_Conditions_Detail>
    {
        public Spartan_BR_Conditions_DetailMap()
        {
            this.ToTable("Spartan_BR_Conditions_Detail");
            this.HasKey(a => a.ConditionsDetailId);
            this.Ignore(a => a.Id);
        }
    }
}
