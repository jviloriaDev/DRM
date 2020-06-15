using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Contactos_Empresa
{
    public partial class Detalle_Contactos_EmpresaMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Contactos_Empresa.Detalle_Contactos_Empresa>
    {
        public Detalle_Contactos_EmpresaMap()
        {
            this.ToTable("Detalle_Contactos_Empresa");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
