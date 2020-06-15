using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Proveedores
{
    public partial class ProveedoresMap : EntityTypeConfiguration<Spartane.Core.Classes.Proveedores.Proveedores>
    {
        public ProveedoresMap()
        {
            this.ToTable("Proveedores");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
