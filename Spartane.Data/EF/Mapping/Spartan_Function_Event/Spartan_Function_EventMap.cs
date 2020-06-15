using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Function_Event
{
    public partial class Spartan_Function_EventMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Function_Event.Spartan_Function_Event>
    {
        public Spartan_Function_EventMap()
        {
            this.ToTable("Spartan_Function_Event");
            this.HasKey(a => a.Function_Event_Id);
            this.Ignore(a => a.Id);
        }
    }
}
