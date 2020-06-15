using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Process_Event
{
    public partial class Spartan_BR_Process_EventMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Process_Event.Spartan_BR_Process_Event>
    {
        public Spartan_BR_Process_EventMap()
        {
            this.ToTable("Spartan_BR_Process_Event");
            this.HasKey(a => a.ProcessEventId);
            this.Ignore(a => a.Id);
        }
    }
}
