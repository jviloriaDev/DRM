using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Interpretacion_consumo_de_agua
{
    public partial class Interpretacion_consumo_de_aguaMap : EntityTypeConfiguration<Spartane.Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua>
    {
        public Interpretacion_consumo_de_aguaMap()
        {
            this.ToTable("Interpretacion_consumo_de_agua");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
