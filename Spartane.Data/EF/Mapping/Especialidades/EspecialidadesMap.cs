using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Especialidades
{
    public partial class EspecialidadesMap : EntityTypeConfiguration<Spartane.Core.Classes.Especialidades.Especialidades>
    {
        public EspecialidadesMap()
        {
            this.ToTable("Especialidades");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
