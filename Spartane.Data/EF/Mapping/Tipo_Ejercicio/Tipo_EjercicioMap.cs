using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Tipo_Ejercicio
{
    public partial class Tipo_EjercicioMap : EntityTypeConfiguration<Spartane.Core.Classes.Tipo_Ejercicio.Tipo_Ejercicio>
    {
        public Tipo_EjercicioMap()
        {
            this.ToTable("Tipo_Ejercicio");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
