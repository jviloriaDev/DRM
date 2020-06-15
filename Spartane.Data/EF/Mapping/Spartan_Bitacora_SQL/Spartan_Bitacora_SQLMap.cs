using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Bitacora_SQL
{
    public partial class Spartan_Bitacora_SQLMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>
    {
        public Spartan_Bitacora_SQLMap()
        {
            this.ToTable("Spartan_Bitacora_SQL");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
