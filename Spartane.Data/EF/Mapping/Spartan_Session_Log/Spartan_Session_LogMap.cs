using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Session_Log
{
    public partial class Spartan_Session_LogMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Session_Log.Spartan_Session_Log>
    {
        public Spartan_Session_LogMap()
        {
            this.ToTable("Spartan_Session_Log");
            this.HasKey(a => a.Session_Log_Id);
            this.Ignore(a => a.Id);
        }
    }
}
