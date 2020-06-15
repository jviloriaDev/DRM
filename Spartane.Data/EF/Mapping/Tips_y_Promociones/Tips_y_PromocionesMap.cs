using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tips_y_Promociones
{
    public partial class Tips_y_PromocionesMap : EntityTypeConfiguration<Spartane.Core.Classes.Tips_y_Promociones.Tips_y_Promociones>
    {
        public Tips_y_PromocionesMap()
        {
            this.ToTable("Tips_y_Promociones");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
