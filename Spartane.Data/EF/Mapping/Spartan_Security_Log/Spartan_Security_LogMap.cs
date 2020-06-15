using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Security_Log
{
    public partial class Spartan_Security_LogMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Security_Log.Spartan_Security_Log>
    {
        public Spartan_Security_LogMap()
        {
            this.ToTable("Spartan_Security_Log");
            this.HasKey(a => a.Security_Log_Id);
            this.Ignore(a => a.Id);
        }
    }
}
