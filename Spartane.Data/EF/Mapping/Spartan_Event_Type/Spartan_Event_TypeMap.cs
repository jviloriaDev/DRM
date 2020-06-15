using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_Event_Type
{
    public partial class Spartan_Event_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_Event_Type.Spartan_Event_Type>
    {
        public Spartan_Event_TypeMap()
        {
            this.ToTable("Spartan_Event_Type");
            this.HasKey(a => a.Event_Type_Id);
            this.Ignore(a => a.Id);
        }
    }
}
