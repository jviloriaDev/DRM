using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Rutinas
{
    public partial class RutinasMap : EntityTypeConfiguration<Spartane.Core.Classes.Rutinas.Rutinas>
    {
        public RutinasMap()
        {
            this.ToTable("Rutinas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
