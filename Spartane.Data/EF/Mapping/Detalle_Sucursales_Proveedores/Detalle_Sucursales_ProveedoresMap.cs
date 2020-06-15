using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Sucursales_Proveedores
{
    public partial class Detalle_Sucursales_ProveedoresMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Sucursales_Proveedores.Detalle_Sucursales_Proveedores>
    {
        public Detalle_Sucursales_ProveedoresMap()
        {
            this.ToTable("Detalle_Sucursales_Proveedores");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
