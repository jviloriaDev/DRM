using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Facturacion_Vendedores
{
    public partial class Detalle_Facturacion_VendedoresMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores>
    {
        public Detalle_Facturacion_VendedoresMap()
        {
            this.ToTable("Detalle_Facturacion_Vendedores");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
