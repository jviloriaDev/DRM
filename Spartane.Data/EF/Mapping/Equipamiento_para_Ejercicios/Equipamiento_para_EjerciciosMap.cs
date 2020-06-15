using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Equipamiento_para_Ejercicios
{
    public partial class Equipamiento_para_EjerciciosMap : EntityTypeConfiguration<Spartane.Core.Classes.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>
    {
        public Equipamiento_para_EjerciciosMap()
        {
            this.ToTable("Equipamiento_para_Ejercicios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
