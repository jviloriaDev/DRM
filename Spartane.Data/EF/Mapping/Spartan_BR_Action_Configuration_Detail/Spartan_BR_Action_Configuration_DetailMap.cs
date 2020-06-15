using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Action_Configuration_Detail
{
    public partial class Spartan_BR_Action_Configuration_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Action_Configuration_Detail.Spartan_BR_Action_Configuration_Detail>
    {
        public Spartan_BR_Action_Configuration_DetailMap()
        {
            this.ToTable("Spartan_BR_Action_Configuration_Detail");
            this.HasKey(a => a.ActionConfigurationId);
            this.Ignore(a => a.Id);
        }
    }
}
