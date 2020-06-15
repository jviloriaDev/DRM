using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Modifications_Log
{
    public partial class Spartan_BR_Modifications_LogMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log>
    {
        public Spartan_BR_Modifications_LogMap()
        {
            this.ToTable("Spartan_BR_Modifications_Log");
            this.HasKey(a => a.ModificationId);
            this.Ignore(a => a.Id);
        }
    }
}
