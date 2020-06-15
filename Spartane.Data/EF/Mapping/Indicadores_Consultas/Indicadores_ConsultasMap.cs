using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Indicadores_Consultas
{
    public partial class Indicadores_ConsultasMap : EntityTypeConfiguration<Spartane.Core.Classes.Indicadores_Consultas.Indicadores_Consultas>
    {
        public Indicadores_ConsultasMap()
        {
            this.ToTable("Indicadores_Consultas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
