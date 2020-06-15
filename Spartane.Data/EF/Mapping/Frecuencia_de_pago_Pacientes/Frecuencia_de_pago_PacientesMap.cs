using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Frecuencia_de_pago_Pacientes
{
    public partial class Frecuencia_de_pago_PacientesMap : EntityTypeConfiguration<Spartane.Core.Classes.Frecuencia_de_pago_Pacientes.Frecuencia_de_pago_Pacientes>
    {
        public Frecuencia_de_pago_PacientesMap()
        {
            this.ToTable("Frecuencia_de_pago_Pacientes");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
