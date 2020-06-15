using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Resultados_IMC
{
    public partial class Resultados_IMCMap : EntityTypeConfiguration<Spartane.Core.Classes.Resultados_IMC.Resultados_IMC>
    {
        public Resultados_IMCMap()
        {
            this.ToTable("Resultados_IMC");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
