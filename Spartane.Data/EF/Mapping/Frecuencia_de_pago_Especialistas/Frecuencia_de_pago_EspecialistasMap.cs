using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Frecuencia_de_pago_Especialistas
{
    public partial class Frecuencia_de_pago_EspecialistasMap : EntityTypeConfiguration<Spartane.Core.Classes.Frecuencia_de_pago_Especialistas.Frecuencia_de_pago_Especialistas>
    {
        public Frecuencia_de_pago_EspecialistasMap()
        {
            this.ToTable("Frecuencia_de_pago_Especialistas");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
