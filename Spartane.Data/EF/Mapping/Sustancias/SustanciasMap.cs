using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Sustancias
{
    public partial class SustanciasMap : EntityTypeConfiguration<Spartane.Core.Classes.Sustancias.Sustancias>
    {
        public SustanciasMap()
        {
            this.ToTable("Sustancias");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
