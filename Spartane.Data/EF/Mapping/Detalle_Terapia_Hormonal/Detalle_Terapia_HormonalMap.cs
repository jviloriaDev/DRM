using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Terapia_Hormonal
{
    public partial class Detalle_Terapia_HormonalMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal>
    {
        public Detalle_Terapia_HormonalMap()
        {
            this.ToTable("Detalle_Terapia_Hormonal");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
