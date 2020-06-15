using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Solicitud_de_Cita_con_Especialista
{
    public partial class Solicitud_de_Cita_con_EspecialistaMap : EntityTypeConfiguration<Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista.Solicitud_de_Cita_con_Especialista>
    {
        public Solicitud_de_Cita_con_EspecialistaMap()
        {
            this.ToTable("Solicitud_de_Cita_con_Especialista");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
