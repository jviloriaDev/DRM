using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Ubicaciones_Eventos_Empresa
{
    public partial class Ubicaciones_Eventos_EmpresaMap : EntityTypeConfiguration<Spartane.Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>
    {
        public Ubicaciones_Eventos_EmpresaMap()
        {
            this.ToTable("Ubicaciones_Eventos_Empresa");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
