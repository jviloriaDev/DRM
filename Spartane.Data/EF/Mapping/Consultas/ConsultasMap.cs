using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Consultas
{
    public partial class ConsultasMap : EntityTypeConfiguration<Spartane.Core.Classes.Consultas.Consultas>
    {
        public ConsultasMap()
        {
            this.ToTable("Consultas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
