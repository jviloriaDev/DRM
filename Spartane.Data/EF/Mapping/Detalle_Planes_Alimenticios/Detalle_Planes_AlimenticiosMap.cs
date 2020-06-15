using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Planes_Alimenticios
{
    public partial class Detalle_Planes_AlimenticiosMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Planes_Alimenticios.Detalle_Planes_Alimenticios>
    {
        public Detalle_Planes_AlimenticiosMap()
        {
            this.ToTable("Detalle_Planes_Alimenticios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
