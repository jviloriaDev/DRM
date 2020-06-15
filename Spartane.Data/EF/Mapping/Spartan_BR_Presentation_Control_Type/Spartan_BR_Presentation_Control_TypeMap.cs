using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Spartan_BR_Presentation_Control_Type
{
    public partial class Spartan_BR_Presentation_Control_TypeMap : EntityTypeConfiguration<Spartane.Core.Classes.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type>
    {
        public Spartan_BR_Presentation_Control_TypeMap()
        {
            this.ToTable("Spartan_BR_Presentation_Control_Type");
            this.HasKey(a => a.PresentationControlTypeId);
            this.Ignore(a => a.Id);
        }
    }
}
