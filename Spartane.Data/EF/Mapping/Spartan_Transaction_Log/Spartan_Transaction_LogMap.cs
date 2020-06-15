using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Transaction_Log
{
    public partial class Spartan_Transaction_LogMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Transaction_Log.Spartan_Transaction_Log>
    {
        public Spartan_Transaction_LogMap()
        {
            this.ToTable("Spartan_Transaction_Log");
            this.HasKey(a => a.Transaction_Log_Id);
            this.Ignore(a => a.Id);
        }
    }
}
