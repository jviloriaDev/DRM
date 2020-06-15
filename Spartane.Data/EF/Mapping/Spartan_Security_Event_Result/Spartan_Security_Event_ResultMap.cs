using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Security_Event_Result
{
    public partial class Spartan_Security_Event_ResultMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Security_Event_Result.Spartan_Security_Event_Result>
    {
        public Spartan_Security_Event_ResultMap()
        {
            this.ToTable("Spartan_Security_Event_Result");
            this.HasKey(a => a.Security_Event_Result_Id);
            this.Ignore(a => a.Id);
        }
    }
}
