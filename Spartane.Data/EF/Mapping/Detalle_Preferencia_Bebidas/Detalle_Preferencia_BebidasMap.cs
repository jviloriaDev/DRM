using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Preferencia_Bebidas
{
    public partial class Detalle_Preferencia_BebidasMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas>
    {
        public Detalle_Preferencia_BebidasMap()
        {
            this.ToTable("Detalle_Preferencia_Bebidas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
