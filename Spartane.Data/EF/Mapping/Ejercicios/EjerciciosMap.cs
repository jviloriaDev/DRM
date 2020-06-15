using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Ejercicios
{
    public partial class EjerciciosMap : EntityTypeConfiguration<Spartane.Core.Classes.Ejercicios.Ejercicios>
    {
        public EjerciciosMap()
        {
            this.ToTable("Ejercicios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
