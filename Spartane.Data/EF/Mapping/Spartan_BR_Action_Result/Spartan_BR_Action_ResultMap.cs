using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Action_Result
{
    public partial class Spartan_BR_Action_ResultMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Action_Result.Spartan_BR_Action_Result>
    {
        public Spartan_BR_Action_ResultMap()
        {
            this.ToTable("Spartan_BR_Action_Result");
            this.HasKey(a => a.ActionResultId);
            this.Ignore(a => a.Id);
        }
    }
}
