using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.areas_Empresas
{
    public partial class areas_EmpresasMap : EntityTypeConfiguration<Spartane.Core.Classes.areas_Empresas.areas_Empresas>
    {
        public areas_EmpresasMap()
        {
            this.ToTable("areas_Empresas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
