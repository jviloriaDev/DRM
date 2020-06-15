using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Transition_Event_Type
{
    public partial class Spartan_Transition_Event_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Transition_Event_Type.Spartan_Transition_Event_Type>
    {
        public Spartan_Transition_Event_TypeMap()
        {
            this.ToTable("Spartan_Transition_Event_Type");
            this.HasKey(a => a.Transition_Event_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
