using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_de_Registro
{
    public partial class Tipo_de_RegistroMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_de_Registro.Tipo_de_Registro>
    {
        public Tipo_de_RegistroMap()
        {
            this.ToTable("Tipo_de_Registro");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
