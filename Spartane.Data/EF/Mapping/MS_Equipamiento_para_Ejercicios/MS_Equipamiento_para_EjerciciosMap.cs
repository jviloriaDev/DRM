using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Equipamiento_para_Ejercicios
{
    public partial class MS_Equipamiento_para_EjerciciosMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Equipamiento_para_Ejercicios.MS_Equipamiento_para_Ejercicios>
    {
        public MS_Equipamiento_para_EjerciciosMap()
        {
            this.ToTable("MS_Equipamiento_para_Ejercicios");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
