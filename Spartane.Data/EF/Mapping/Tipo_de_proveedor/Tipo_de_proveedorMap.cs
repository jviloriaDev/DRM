using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_proveedor
{
    public partial class Tipo_de_proveedorMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_proveedor.Tipo_de_proveedor>
    {
        public Tipo_de_proveedorMap()
        {
            this.ToTable("Tipo_de_proveedor");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
