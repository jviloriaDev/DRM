using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Codigos_de_Referencia_Vendedores
{
    public partial class Detalle_Codigos_de_Referencia_VendedoresMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Codigos_de_Referencia_Vendedores.Detalle_Codigos_de_Referencia_Vendedores>
    {
        public Detalle_Codigos_de_Referencia_VendedoresMap()
        {
            this.ToTable("Detalle_Codigos_de_Referencia_Vendedores");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
