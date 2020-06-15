using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Suscripciones_Empresa
{
    public partial class Detalle_Suscripciones_EmpresaMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>
    {
        public Detalle_Suscripciones_EmpresaMap()
        {
            this.ToTable("Detalle_Suscripciones_Empresa");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
