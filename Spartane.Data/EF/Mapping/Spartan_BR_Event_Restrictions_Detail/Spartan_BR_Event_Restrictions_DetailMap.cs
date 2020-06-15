using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Event_Restrictions_Detail
{
    public partial class Spartan_BR_Event_Restrictions_DetailMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Event_Restrictions_Detail.Spartan_BR_Event_Restrictions_Detail>
    {
        public Spartan_BR_Event_Restrictions_DetailMap()
        {
            this.ToTable("Spartan_BR_Event_Restrictions_Detail");
            this.HasKey(a => a.RestrictionId);
            this.Ignore(a => a.Id);
        }
    }
}
