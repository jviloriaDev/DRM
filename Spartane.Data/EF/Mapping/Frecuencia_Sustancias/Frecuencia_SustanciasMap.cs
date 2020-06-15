using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Frecuencia_Sustancias
{
    public partial class Frecuencia_SustanciasMap : EntityTypeConfiguration<Spartane.Core.Classes.Frecuencia_Sustancias.Frecuencia_Sustancias>
    {
        public Frecuencia_SustanciasMap()
        {
            this.ToTable("Frecuencia_Sustancias");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
