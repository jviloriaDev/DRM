using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Pagos_Empresa
{
    public partial class Detalle_Pagos_EmpresaMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Pagos_Empresa.Detalle_Pagos_Empresa>
    {
        public Detalle_Pagos_EmpresaMap()
        {
            this.ToTable("Detalle_Pagos_Empresa");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
