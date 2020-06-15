using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.MS_Suscripciones_Codigos_Referidos_Especialista
{
    public partial class MS_Suscripciones_Codigos_Referidos_EspecialistaMap : EntityTypeConfiguration<Spartane.Core.Classes.MS_Suscripciones_Codigos_Referidos_Especialista.MS_Suscripciones_Codigos_Referidos_Especialista>
    {
        public MS_Suscripciones_Codigos_Referidos_EspecialistaMap()
        {
            this.ToTable("MS_Suscripciones_Codigos_Referidos_Especialista");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
