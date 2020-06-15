using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Security_Event_Type
{
    public partial class Spartan_Security_Event_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Security_Event_Type.Spartan_Security_Event_Type>
    {
        public Spartan_Security_Event_TypeMap()
        {
            this.ToTable("Spartan_Security_Event_Type");
            this.HasKey(a => a.Security_Event_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
