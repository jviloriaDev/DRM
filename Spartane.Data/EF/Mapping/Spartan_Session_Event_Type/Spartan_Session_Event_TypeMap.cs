using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Session_Event_Type
{
    public partial class Spartan_Session_Event_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Session_Event_Type.Spartan_Session_Event_Type>
    {
        public Spartan_Session_Event_TypeMap()
        {
            this.ToTable("Spartan_Session_Event_Type");
            this.HasKey(a => a.Session_Event_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
