using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Empresas
{
    public partial class EmpresasMap : EntityTypeConfiguration<Spartane.Core.Classes.Empresas.Empresas>
    {
        public EmpresasMap()
        {
            this.ToTable("Empresas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
