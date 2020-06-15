using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Resultados_Consultas
{
    public partial class Detalle_Resultados_ConsultasMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Resultados_Consultas.Detalle_Resultados_Consultas>
    {
        public Detalle_Resultados_ConsultasMap()
        {
            this.ToTable("Detalle_Resultados_Consultas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
