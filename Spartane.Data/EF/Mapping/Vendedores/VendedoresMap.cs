using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Vendedores
{
    public partial class VendedoresMap : EntityTypeConfiguration<Spartane.Core.Classes.Vendedores.Vendedores>
    {
        public VendedoresMap()
        {
            this.ToTable("Vendedores");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
