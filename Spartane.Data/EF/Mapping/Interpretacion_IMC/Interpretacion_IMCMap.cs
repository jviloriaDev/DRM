using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Interpretacion_IMC
{
    public partial class Interpretacion_IMCMap : EntityTypeConfiguration<Spartane.Core.Classes.Interpretacion_IMC.Interpretacion_IMC>
    {
        public Interpretacion_IMCMap()
        {
            this.ToTable("Interpretacion_IMC");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
