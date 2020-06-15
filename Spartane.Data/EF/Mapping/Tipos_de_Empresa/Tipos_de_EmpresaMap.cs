using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipos_de_Empresa
{
    public partial class Tipos_de_EmpresaMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipos_de_Empresa.Tipos_de_Empresa>
    {
        public Tipos_de_EmpresaMap()
        {
            this.ToTable("Tipos_de_Empresa");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
